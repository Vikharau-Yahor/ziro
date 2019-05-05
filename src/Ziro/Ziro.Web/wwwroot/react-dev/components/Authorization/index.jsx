import React, { Component } from 'react'
//material ui
import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
import Button from '@material-ui/core/Button';
import Avatar from '@material-ui/core/Avatar';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import FormControl from '@material-ui/core/FormControl';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Input from '@material-ui/core/Input';
import InputAdornment from '@material-ui/core/InputAdornment';
import InputLabel from '@material-ui/core/InputLabel';
import Checkbox from '@material-ui/core/Checkbox';
import IconButton from '@material-ui/core/IconButton';
import Visibility from '@material-ui/icons/Visibility';
import VisibilityOff from '@material-ui/icons/VisibilityOff';
import withStyles from '@material-ui/core/styles/withStyles';

import { Redirect } from 'react-router';
import { fetchData } from '../../utils.js';


const styles = theme => ({
   paper: {
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center',
      width: 400,
      marginTop: '5%',
      marginLeft: 'auto',
      marginRight: 'auto',
      //spacing.unit = 8
      padding: `${theme.spacing.unit * 2}px ${theme.spacing.unit * 5}px ${theme.spacing.unit * 3}px`,
   },
   avatar: {
      margin: theme.spacing.unit,
      backgroundColor: theme.palette.secondary.main,
   },
   form: {
      //width: '92%', // Fix IE 11 issue.
      //marginTop: theme.spacing.unit,
   },
   errorMessage: {
      color: '#f00',
      transition: 'all .5s ease',
      fontSize: '.875em',
      opacity: 0
   },
   remember: {
      display: 'flex'
   },
   submit: {
      display: 'flex',
      width: '50%',
      margin: `${theme.spacing.unit * 3}px auto 0`,
   },
});

class Authorization extends Component {
   constructor(props) {
      super(props);
      this.state = {
         email: 'test@mail.com',
         password: '123',
         showPassword: false,
      };
      this.handleClick = this.handleClick.bind(this);
      this.successLogin = this.successLogin.bind(this);
   }

   handleClickShowPassword = () => {
      this.setState(state => ({ showPassword: !state.showPassword }));
   };

   handleEmailChange(e) {
      this.setState({ email: e.target.value });
   }
   handlePasswordChange(e) {
      this.setState({ password: e.target.value });
   }

   successLogin(response) {
      var responseText = JSON.stringify(response);
      this.setState({ email: '' });
      alert(responseText);
      return <Redirect to="/adminpanel" />
      
   }

   errorLogin(error) {
      alert(error);
   }

   handleClick(e) {
      e.preventDefault();
      var requestData = {
         email: this.state.email,
         password: this.state.password
      };
      fetchData('api/account/login', 'POST', requestData, this.successLogin, this.errorLogin);
   }

   render() {
      const { classes } = this.props;
      return (
         <div className="container">
            <Paper className={classes.paper}>
               <Avatar className={classes.avatar}>
                  <LockOutlinedIcon />
               </Avatar>
               <Typography color="textPrimary" component="h1" variant="h5">Вход</Typography>
               <form className={`${classes.form} authorization-form`} action="">
                  <FormControl error margin="normal" required fullWidth>
                     <InputLabel htmlFor="email">Email</InputLabel>
                     <Input id="email" type="email" name="email" autoComplete="email" autoFocus value={this.state.email} onChange={this.handleEmailChange.bind(this)} />
                     <Typography className={classes.errorMessage} component="span" variant="p">error</Typography>
                  </FormControl>
                  <FormControl margin="normal" required fullWidth>
                     <InputLabel htmlFor="password">Пароль</InputLabel>
                     <Input 
                        id="password"
                        name="password"
                        type={this.state.showPassword ? 'text' : 'password'}                        
                        autoComplete="current-password" 
                        value={this.state.password} 
                        onChange={this.handlePasswordChange.bind(this)}
                        endAdornment={
                           <InputAdornment position="end">
                             <IconButton
                               aria-label="Toggle password visibility"
                               onClick={this.handleClickShowPassword}
                             >
                               {this.state.showPassword ? <Visibility /> : <VisibilityOff />}
                             </IconButton>
                           </InputAdornment>
                         }
                      />
                     <Typography className={classes.errorMessage} component="span" variant="p">error</Typography>
                  </FormControl>
                  <FormControlLabel className={classes.remember}
                     control={<Checkbox value="remember" color="primary" />}
                     label="Запомнить"
                  />
                  <Button variant="contained" color="primary" onClick={this.handleClick} className={classes.submit}>Войти</Button>
               </form>
            </Paper>
         </div>
      )
   }
}

Authorization.propTypes = {
   classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Authorization);