import React, { Component } from 'react';
import PropTypes from 'prop-types';
//import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';
import TextField from '@material-ui/core/TextField';
//import Icon from '@material-ui/core/Icon';
//import NavigationIcon from '@material-ui/icons/Navigation';
import Button from '@material-ui/core/Button';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
// import List from '@material-ui/core/List';
// import ListItem from '@material-ui/core/ListItem';
// import ListItemAvatar from '@material-ui/core/ListItemAvatar';
// import ListItemText from '@material-ui/core/ListItemText';
import DialogTitle from '@material-ui/core/DialogTitle';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import { DropzoneArea } from 'material-ui-dropzone'
//import blue from '@material-ui/core/colors/blue';
import withStyles from '@material-ui/core/styles/withStyles';
import { fetchGetData, isUserAuthenticated } from '../../utils.js';

const styles = theme => ({
   root: {
      display: 'flex',
      flexWrap: 'wrap',
      marginTop: '30px'
   },
   // paper: {
   //    marginTop: theme.spacing.unit * 3,
   //    marginBottom: theme.spacing.unit * 3,
   //    padding: theme.spacing.unit * 2,
   //    [theme.breakpoints.up(600 + theme.spacing.unit * 3 * 2)]: {
   //       width: 900,
   //       marginLeft: 'auto',
   //       marginRight: 'auto',
   //       marginTop: theme.spacing.unit * 6,
   //       marginBottom: theme.spacing.unit * 6,
   //       padding: theme.spacing.unit * 3,
   //    },
   // },
   dialogTitle: {
      padding: '30px'
   },
   dialogContent: {
      padding: '0 30px 30px'
   },
   formControl: {
      margin: theme.spacing.unit,
      minWidth: 120,
   },
   selectEmpty: {
      marginTop: theme.spacing.unit * 2,
   },
   gridBtnCancel: {
      marginRight: '30px'
   }
});

class AddTaskForm extends Component {
   constructor(props) {
      super(props);

      // if (!isUserAuthenticated()) {
      //    this.props.history.push('/authorization');
      //    return;
      // }

      this.state = {
         files: [],
         //types: [],
         //priorities: [],
         selectedType: '',
         selectedPriority: ''
      };
      this.types = [];
      this.priorities = [];
      this.assignee = [];
   }

   handleChange = event => {
      this.setState({ [event.target.name]: event.target.value });
   };

   handleUpload(files) {
      this.setState({
         files: files
      });
   }

   successGetTypesData = (response) => {
      let arr = response.data;
      let types = [];
      for (let key in arr) {
         types.push({
            val: key,
            text: arr[key]
         })
      }
      if (!response.errors) {
         // this.setState({
         //    types: types
         // })
         this.types = types;
      }
   }

   successGetPrioritiesData = (response) => {
      let arr = response.data;
      let priorities = [];
      for (let key in arr) {
         priorities.push({
            val: key,
            text: arr[key]
         })
      }
      if (!response.errors) {
         this.priorities = priorities;
      }
   }

   errorGetData = (error) => {
      alert(error);
   }

   getFormData = () => {
      fetchGetData('api/task/getAvailableTypes', this.successGetTypesData, this.errorGetData);
      fetchGetData('api/task/getavailablePriorities', this.successGetPrioritiesData, this.errorGetData);
   }

   render() {
      const { classes } = this.props;
      // const typesItems = this.types.map((elem) => <MenuItem value={elem.val}>{elem.text}</MenuItem> )
      // const prioritiesItems = this.priorities.map((elem) => <MenuItem value={elem.val}>{elem.text}</MenuItem> )
      return (
         <div className="container">
            <Dialog
               open={this.props.open}
               onEntered={this.getFormData}
               aria-labelledby="dialog-title"
               maxWidth="md"
               keepMounted
            >
               <DialogTitle className={classes.dialogTitle} id="dialog-title">Новая задача</DialogTitle>
               <DialogContent className={classes.dialogContent}>
                  <form className={`${classes.root} add-form`} action="">
                     <Grid className="grid__container" container spacing={24}>
                        <Grid className="grid__item" item xs={12}>
                           <TextField
                              id="title"
                              name="title"
                              label="Название"
                              fullWidth
                              autoComplete="title"
                           />
                        </Grid>
                        <Grid className="grid__item" item xs={12}>
                           <TextField
                              id="description"
                              label="Описание"
                              multiline
                              rowsMax="4"
                              //value={this.state.multiline}
                              fullWidth
                           />
                        </Grid>
                        <Grid className="grid__item" item xs={12} sm={6}>
                           <FormControl
                              className={classes.formControl}
                              fullWidth
                           >
                              <InputLabel htmlFor="task-types">Тип задачи</InputLabel>
                              <Select
                                 value={this.state.selectedType}
                                 onChange={this.handleChange}
                                 inputProps={{
                                    name: 'selectedType',
                                    id: 'task-types',
                                 }}
                              >
                                 <MenuItem value=""><em>None</em></MenuItem>
                                 {/* {typesItems} */}
                                 <MenuItem value="0">Задача</MenuItem>
                                 <MenuItem value="3">Под-задача</MenuItem>
                                 <MenuItem value="2">Нововведение</MenuItem>
                                 <MenuItem value="1">Дефект</MenuItem>
                              </Select>
                           </FormControl>
                        </Grid>
                        <Grid className="grid__item" item xs={12} sm={6}>
                           <FormControl
                              className={classes.formControl}
                              fullWidth
                           >
                              <InputLabel htmlFor="priority-types">Приоритет</InputLabel>
                              <Select
                                 value={this.state.selectedPriority}
                                 onChange={this.handleChange}
                                 inputProps={{
                                    name: 'selectedPriority',
                                    id: 'priority-types',
                                 }}
                              >
                                 <MenuItem value=""><em>None</em></MenuItem>
                                 {/* {prioritiesItems} */}
                                 <MenuItem value="0">Тривиальный</MenuItem>
                                 <MenuItem value="1">Низкий</MenuItem>
                                 <MenuItem value="2">Высокий</MenuItem>
                                 <MenuItem value="3">Критический</MenuItem>
                                 <MenuItem value="4">Блокирующий</MenuItem>
                              </Select>
                           </FormControl>
                        </Grid>
                        <Grid className="grid__item" item xs={12} sm={6}>
                           <FormControl
                              className={classes.formControl}
                              fullWidth
                           >
                              <InputLabel htmlFor="task-assignee">Назначить</InputLabel>
                              <Select
                                 value={this.state.assignee}
                                 onChange={this.handleChange}
                                 inputProps={{
                                    name: 'assignee',
                                    id: 'task-assignee',
                                 }}
                              >
                                 <MenuItem value=""><em>None</em></MenuItem>
                                 {/* {typesItems} */}
                                 <MenuItem value="0">Шикайло Сергей</MenuItem>
                                 <MenuItem value="2">Ургант Максим</MenuItem>
                                 <MenuItem value="3">Шевченко Дарья</MenuItem>
                              </Select>
                           </FormControl>
                        </Grid>
                        <Grid className="grid__item" item xs={12} sm={6}>
                           <TextField
                              id="estimatedTime"
                              name="estimatedTime"
                              label="Запланированное время"
                              fullWidth
                           />
                        </Grid>
                        <Grid className="grid__item upload__item" item xs={12} sm={6}>
                           <Typography className="upload__text" component="h6" variant="h6">Прикрепить изображение</Typography>
                           <Typography className="upload__tip" component="span" variant="h6">Перетяните изображение сюда или кликните</Typography>
                           <DropzoneArea
                              onChange={this.handleUpload.bind(this)}
                           />
                        </Grid>
                        <Grid className="grid__item grid__item-btns" item xs={12}>
                           <DialogActions>
                              <Button onClick={this.props.handleClose} variant="contained" color="primary" className={`${classes.gridBtnCancel}`}>
                                 Отмена
                           </Button>
                              <Button onClick={this.props.handleClose} variant="contained" color="primary">
                                 Добавить
                           </Button>
                           </DialogActions>
                        </Grid>
                     </Grid>
                  </form>
               </DialogContent>
            </Dialog>
         </div>
      )
   }
}

AddTaskForm.propTypes = {
   classes: PropTypes.object.isRequired,
   onClose: PropTypes.func,
};
export default withStyles(styles)(AddTaskForm);