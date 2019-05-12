import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
//import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Icon from '@material-ui/core/Icon';
import NavigationIcon from '@material-ui/icons/Navigation';
import DeleteIcon from '@material-ui/icons/Delete';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import withStyles from '@material-ui/core/styles/withStyles';
import './task.css'
import { isUserAuthenticated, fetchPostData } from '../../utils.js'

class Log extends Component {
   render() {
      return (
         <div className="tab__content">
            {this.props.td.map((elem, index) =>
               <div className="comment__item" key={index}>
                  <p className="comment__author">{elem.author.fullName}</p>
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
   render() {
      return (
         <div className="tab__content">
            {this.props.td.map((elem, index) =>
               <div className="comment__item" key={index}>
                  <p className="comment__author">{elem.author.fullName}</p>
                  <p className="comment__text">{elem.text}</p>
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
         isOwner: true, //test field
         isActiveStatus: false,
         value: 0
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
      var task = response.data;
      if (!response.errors) {
         this.setState({
            taskDetails: task
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

   render() {
      const { classes } = this.props;
      var task_d = this.state.taskDetails;
      var { value } = this.state;
      return (
         <div className="container">
            <div className="task__wrap">
               <Paper className="task__block">
                  <div className="task__section-wrap">
                     <h1 className="task__title"><span className="task__number">{task_d.number}</span>{task_d.title}</h1>
                     <div className="task__section task__owner-block">
                        <p className="task__owner-text">
                           <span className="task__creator">{task_d.owner.fullName}</span>открыл эту задачу
                        <span className="task__creation-date">{task_d.creationDate}</span> - <span className="task__comments-number">{task_d.comments.length}</span> комментариев</p>
                     </div>
                     <div className="task__section task__buttons-block">
                        {this.state.isOwner ?
                           <>
                              <Button variant="contained" className={`${classes.eventBtn} event__btn`}>
                                 <Icon>edit_icon</Icon>
                                 Редактировать
                              </Button>
                              <Button variant="contained" className={`${classes.eventBtn} event__btn`}>
                                 <NavigationIcon />
                                 Назначить
                              </Button>
                              <Button variant="contained" className={`${classes.eventBtn} event__btn`}>
                                 <DeleteIcon />
                                 Удалить
                              </Button>
                           </>
                           : null}
                     </div>
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
                     {value === 1 && <Comments td={task_d.comments} />}
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