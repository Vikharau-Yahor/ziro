import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Icon from '@material-ui/core/Icon';
import NavigationIcon from '@material-ui/icons/Navigation';
import DeleteIcon from '@material-ui/icons/Delete';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import withStyles from '@material-ui/core/styles/withStyles';
import './task.css'
import { isUserAuthenticated, fetchPostData } from '../../utils.js'
import AssigneeWin from './AssigneeWin.jsx'
import EditTaskForm from './EditTaskForm.jsx';

class Log extends Component {
   render() {
      return (
         <div className="tab__content">
            {this.props.td.map((elem, index) =>
               <div className="comment__item" key={index}>
                  <p className="comment__author"><img src={`/api/user/getAvatar?userId=${elem.author.id}`} alt="avatar" />{elem.author.fullName}</p>
                  <p className="comment__text">{elem.text}</p>
                  <p className="comment__text">Заняло времени: {elem.spentTimeHours} часа</p>
                  <p className="comment__date">{elem.leavingDate}</p>
               </div>
            )}
            <div className="new-comment_wrap">
               <textarea name="" id="" placeholder="Добавить комментарий..."></textarea>
               <Button variant="contained" color="primary">Отправить</Button>
            </div>
         </div>
      )
   }
}

class Comments extends Component {
   constructor(props) {
      super(props);
      this.state = {
         newComment: ''
      }
   }

   handleChange = (e) => {
      //if((e.target.value != null) && (e.target.value !='')) {
         this.setState({ newComment: e.target.value });
      //}
   }

   successComment = (response) => {
           // var responseText = JSON.stringify(response);
      //alert(responseText);
      //window.location.reload()
      //location.reload();
      //this.props.history.push(`/task/${this.props.td_number}`);
	}

   errorComment = (error) => {
      alert(error);
   }

   handleClick = (e) => {
      e.preventDefault();
      var requestData = {
         taskId: this.props.td_id,
         text: this.state.newComment
      };
      // var responseText = JSON.stringify(requestData);
      // alert(responseText)
	  fetchPostData('api/task/addComment', requestData, this.successComment, this.errorComment);
   }

   render() {
      return (
         <div className="tab__content">
            {this.props.td_comments.map((elem, index) =>
               <div className="comment__item" key={index}>
                  <p className="comment__author"><img src={`/api/user/getAvatar?userId=${elem.author.id}`} alt="avatar" /> {elem.author.fullName}</p>
                  <p className="comment__text">{elem.text}</p>
                  <p className="comment__date">{elem.leavingDate}</p>
               </div>
            )}
            <div className="new-comment_wrap">
               <textarea 
                  name=""
                  id="" 
                  placeholder="Добавить комментарий..."
                  //value={this.state.newComment} 
                  onChange={this.handleChange}
               >
               </textarea>
               <Button onClick={this.handleClick} variant="contained" color="primary">Отправить</Button>
            </div>
         </div>
      )
   }
}

class DeleteWin extends Component {
   constructor(props) {
      super(props);
      this.state = {
         //files: [],
      };
   }

   handleDeleteTask = () => {
      this.props.history.push('/');
      return;
   }

   render() {
      return (
         <Dialog
            onClose={this.handleClose}
            //aria-labelledby="customized-dialog-title"
            open={this.props.openDeleteDialog}
            maxWidth="xs"
         >
            <DialogContent>
               <Typography variant="body2">Вы действительно хотите удалить задачу?</Typography>
            </DialogContent>
            <DialogActions>
               <Button onClick={this.props.handleCloseDeleteDialog} color="default">Отмена</Button>
               <Button onClick={this.handleDeleteTask} color="primary">Да</Button>
            </DialogActions>
         </Dialog>
      )
   }
}

const styles = theme => ({
   statusBtn: {
      marginBottom: '10px'
   },
   eventBtn: {
      marginRight: '20px'
   },
   tabWrap: {
      flexGrow: 1,
      width: '100%',
      backgroundColor: theme.palette.background.paper,
   },
   tabsRoot: {
      borderBottom: '1px solid #e8e8e8',
   },
   tabsIndicator: {
      backgroundColor: '#1890ff',
   },
   tabRoot: {
      fontSize: '1em',
      textTransform: 'initial',
      minWidth: 72,
      fontWeight: theme.typography.fontWeightRegular,
      marginRight: theme.spacing.unit * 4,
      '&:hover': {
         color: '#40a9ff',
      },
      '&$tabSelected': {
         color: '#1890ff',
         fontWeight: theme.typography.fontWeightMedium,
      },
      '&:focus': {
         color: '#40a9ff',
      },
   },
   tabSelected: {},
});

class Task extends Component {
   constructor(props) {
      super(props);
      this.state = {
         taskDetails: {
            project: {},
            assignee: {},
            owner: {},
            comments: [{ author: {} }],
            logWorks: []
         },
         currentAssignee: {},
         isOwner: true, //test field
         isActiveStatus: false,
         value: 0,
         openEditDialog: false,
         openAssigneeDialog: false,
         openDeleteDialog: false,
         // newComment: '',
         // newLog: ''
      }
      if (!isUserAuthenticated()) {
         this.props.history.push('/authorization');
         return;
      }
      var requestData = {
         taskNumber: this.props.match.params.task_number
      };
      fetchPostData('api/task/getTaskDetailsByNumber', requestData, this.successGetTaskData, this.errorGetTaskData);
   }

   successGetTaskData = (response) => {
      // var responseText = JSON.stringify(response.data);
      // alert(responseText);
      if (!response.errors) {
         this.setState({
            taskDetails: response.data,
            currentAssignee: response.data.assignee
         })
      }
   }

   errorGetTaskData = (error) => {
      alert(error);
   }

   toggleStatus = (e) => {
      var taskD = this.state.taskDetails;
      taskD.statusNum = e.currentTarget.getAttribute('statusNum');
      this.setState({ taskDetails: taskD });
   }

   tabChange = (event, value) => {
      this.setState({ value });
   };

   handleClickAssignee = () => {
      this.setState({ openAssigneeDialog: true });
   };

   handleCloseAssigneeDialog = currentAssignee => {
      this.setState({ currentAssignee, openAssigneeDialog: false });
   };
   handleCloseEditFormDialog = () => {
      this.setState({ openEditDialog: false });
   };
   handleCloseDeleteDialog = () => {
      this.setState({ openDeleteDialog: false });
   };

   render() {
      const { classes } = this.props;
      var task_d = this.state.taskDetails;
      var { value } = this.state;
      return (
         <div className="container">
            <div className="dialog-block">
               {/* <AssigneeWin
                  open={this.state.openAssigneeDialog}
                  handleClose={this.handleCloseAssigneeDialog}
                  value={this.state.currentAssignee}
               /> */}
               <EditTaskForm
                  open={this.state.openEditDialog}
                  handleClose={this.handleCloseEditFormDialog}
                  taskData={this.state.taskDetails}
               />
               <DeleteWin
                  open={this.state.openDeleteDialog}
                  handleClose={this.handleCloseDeleteDialog}
               />
            </div>
            <div className="task__wrap">
               <Paper className="task__block">
                  <div className="task__section-wrap">
                     <h1 className="task__title"><span className="task__number">{task_d.number}</span>{task_d.title}</h1>
                     <div className="task__section task__owner-block">
                        <p className="task__owner-text">
                           <span className="task__creator">{task_d.owner.fullName}</span>открыл эту задачу
                        <span className="task__creation-date">{task_d.creationDate}</span> - <span className="task__comments-number">{task_d.comments.length}</span> комментариев</p>
                     </div>

                     {this.state.isOwner ?
                        <div className="task__section task__buttons-block">
                           <Button variant="contained" className={`${classes.eventBtn} event__btn`}>
                              <Icon>edit_icon</Icon>
                              Редактировать
                              </Button>
                           <Button variant="contained" className={`${classes.eventBtn} event__btn`}
                              onClick={this.handleClickAssignee}
                           >
                              <NavigationIcon />
                              Назначить
                              </Button>
                           <Button variant="contained" className={`${classes.eventBtn} event__btn`}>
                              <DeleteIcon />
                              Удалить
                              </Button>
                        </div>
                        : null}

                     <div className="task__section task__details-block">
                        <h2 className="section__title">Детали</h2>
                        <p className="task__status"><span className="key">Статус:</span> <span className="value">{task_d.status}</span></p>
                        <p className="task__type"><span className="key">Тип:</span> <span className="value">{task_d.type}</span></p>
                        <p className="task__priority"><span className="key">Приоритет:</span> <span className={`value value${task_d.priorityNum}`}>{task_d.priority}</span></p>
                     </div>
                     <div className="task__section task__description-block">
                        <h2 className="section__title">Описание</h2>
                        <p className="task__description">{task_d.description}</p>
                        <img className="task__img" src="https://user-images.githubusercontent.com/2376915/31859948-e42fd92e-b71b-11e7-9383-3459f8aa3af5.png" />
                     </div>
                  </div>
                  <div className="task__set-status-block">
                     <h2 className="section__title">Установить статус</h2>
                     <Button
                        className={`${classes.statusBtn} status__btn`}
                        variant={task_d.statusNum == 0 ? "contained" : "outlined"}
                        color={task_d.statusNum == 0 ? "primary" : null}
                        onClick={this.toggleStatus}
                        statusNum="0"
                     // className={this.state.isActiveStatus ? "active" : ''}
                     >
                        Открыто
                     </Button>
                     <Button
                        className={`${classes.statusBtn} status__btn`}
                        variant={task_d.statusNum == 1 ? "contained" : "outlined"}
                        color={task_d.statusNum == 1 ? "primary" : null}
                        onClick={this.toggleStatus}
                        statusNum="1"
                     >
                        Выполняется
                     </Button>
                     <Button
                        className={`${classes.statusBtn} status__btn`}
                        variant={task_d.statusNum == 2 ? "contained" : "outlined"}
                        color={task_d.statusNum == 2 ? "primary" : null}
                        onClick={this.toggleStatus}
                        statusNum="2"
                     >
                        Верификация
                     </Button>
                     <Button
                        className={`${classes.statusBtn} status__btn`}
                        variant={task_d.statusNum == 3 ? "contained" : "outlined"}
                        color={task_d.statusNum == 3 ? "primary" : null}
                        onClick={this.toggleStatus}
                        statusNum="3"
                     >
                        Тестирование
                     </Button>
                     <Button
                        className={`${classes.statusBtn} status__btn`}
                        variant={task_d.statusNum == 4 ? "contained" : "outlined"}
                        color={task_d.statusNum == 4 ? "primary" : null}
                        onClick={this.toggleStatus}
                        statusNum="4"
                     >
                        Завершено
                     </Button>
                  </div>
               </Paper>
               <Paper className="comments__block">
                  <div className={classes.tabWrap}>
                     <Tabs
                        value={value}
                        onChange={this.tabChange}
                        variant="scrollable"
                        // scrollButtons="auto"
                        classes={{ root: classes.tabsRoot, indicator: classes.tabsIndicator }}
                     >
                        <Tab
                           classes={{ root: classes.tabRoot, selected: classes.tabSelected }}
                           label="Журнал работ" />
                        <Tab
                           classes={{ root: classes.tabRoot, selected: classes.tabSelected }}
                           label="Комментарии" />
                     </Tabs>

                     {value === 0 && <Log td={task_d.logWorks} />}
                     {value === 1 && <Comments td_comments={task_d.comments} td_id={task_d.id} td_number={task_d.number}/>}
                  </div>
               </Paper>
            </div>
         </div>
      )
   }
}

Task.propTypes = {
   classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Task)