import React, { Component, useState } from 'react';
import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';
import TextField from '@material-ui/core/TextField';
import Checkbox from '@material-ui/core/Checkbox';
import Button from '@material-ui/core/Button';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import { DropzoneArea } from 'material-ui-dropzone'
import { DropzoneDialog } from 'material-ui-dropzone';
import withStyles from '@material-ui/core/styles/withStyles';
import './adminpanel.css'

const styles = theme => ({
   root: {
      display: 'flex',
      flexWrap: 'wrap',
   },
   paper: {
      marginTop: theme.spacing.unit * 3,
      marginBottom: theme.spacing.unit * 3,
      padding: theme.spacing.unit * 2,
      [theme.breakpoints.up(600 + theme.spacing.unit * 3 * 2)]: {
         width: 800,
         marginLeft: 'auto',
         marginRight: 'auto',
         marginTop: theme.spacing.unit * 6,
         marginBottom: theme.spacing.unit * 6,
         padding: theme.spacing.unit * 3,
      },
   },
   formControl: {
      margin: theme.spacing.unit,
      minWidth: 120,
   },
   selectEmpty: {
      marginTop: theme.spacing.unit * 2,
   },
   avatar: {
      margin: theme.spacing.unit,
      backgroundColor: theme.palette.secondary.main,
   },
});

class AdminPanel extends Component {
   constructor(props) {
      super(props);
      this.state = {
         files: []
      };
   }
   state = {
      position: '',
      name: 'hai',
   };

   handleChange = event => {
      this.setState({ [event.target.name]: event.target.value });
   };

   handleUpload(files) {
      this.setState({
         files: files
      });
   }

   render() {
      const { classes } = this.props;
      return (
         <div className="container">
            <Paper className={classes.paper}>
               <Typography component="h1" variant="h5" align="center">Добавление нового сотрудника</Typography>
               <form className={`${classes.root} add-employee-form`} action="">
                  <Grid className="grid__container" container spacing={24}>
                     <Grid className="grid__item" item xs={12} sm={6}>
                        <TextField
                           required
                           id="firstName"
                           name="firstName"
                           label="Имя"
                           fullWidth
                           autoComplete="fname"
                        />
                     </Grid>
                     <Grid className="grid__item" item xs={12} sm={6}>
                        <TextField
                           required
                           id="lastName"
                           name="lastName"
                           label="Фамилия"
                           fullWidth
                           autoComplete="lname"
                        />
                     </Grid>
                     <Grid className="grid__item" item xs={12} sm={6}>
                        <TextField
                           required
                           id="patronymic"
                           name="patronymic"
                           label="Отчество"
                           fullWidth
                           autoComplete="patronymic"
                        />
                     </Grid>
                     <Grid className="grid__item" item xs={12} sm={6}>
                        <TextField
                           required
                           id="email"
                           name="email"
                           label="Email"
                           type="email"
                           fullWidth
                           autoComplete="email"
                        />
                     </Grid>
                     <Grid className="grid__item" item xs={12} sm={6}>
                        <TextField
                           required
                           id="skype"
                           name="skype"
                           label="Skype"
                           fullWidth
                           autoComplete="skype"
                        />
                     </Grid>
                     <Grid className="grid__item" item xs={12} sm={6}>
                        <TextField
                           required
                           id="phone"
                           name="phone"
                           label="Контактный телефон"
                           type="phone"
                           fullWidth
                           autoComplete="phone"
                        />
                     </Grid>
                     <Grid className="grid__item" item xs={12} sm={6}>
                        <FormControl 
                           required
                           className={classes.formControl}
                           fullWidth
                           >
                           <InputLabel htmlFor="position-simple">Должность</InputLabel>
                           <Select
                              value={this.state.position}
                              onChange={this.handleChange}
                              inputProps={{
                                 name: 'position',
                                 id: 'position-simple',
                              }}
                           >
                              <MenuItem value="">
                                 <em>None</em>
                              </MenuItem>
                              <MenuItem value={101}>Backend developer</MenuItem>
                              <MenuItem value={102}>ASP.NET developer</MenuItem>
                              <MenuItem value={103}>Frontend developer</MenuItem>
                              <MenuItem value={104}>Frontend (React) developer</MenuItem>
                              <MenuItem value={105}>IOS developer</MenuItem>
                           </Select>
                        </FormControl>
                     </Grid>
                     <Grid className="grid__item" item xs={12} sm={6}>
                        <TextField
                           required
                           id="date"
                           label="Дата рождения"
                           type="date"
                           fullWidth
                           InputLabelProps={{
                              shrink: true,
                           }}
                        />
                     </Grid>
                     <Grid className="grid__item upload__item" item xs={12} sm={6}>
                     <Typography className="upload__text" component="h6" variant="h6">Выберите фото профиля</Typography>
                     <Typography className="upload__tip" component="span" variant="h6">Перетяните изображение сюда или кликните</Typography>
                        <DropzoneArea
                           onChange={this.handleUpload.bind(this)}
                        />
                     </Grid>
                     <Grid className="grid__item" item xs={12}>
                        <Button type="submit" variant="contained" color="primary">Сохранить</Button>
                     </Grid>
                  </Grid>
               </form>
            </Paper>
         </div>
      )
   }
}

AdminPanel.propTypes = {
   classes: PropTypes.object.isRequired,
};
export default withStyles(styles)(AdminPanel);