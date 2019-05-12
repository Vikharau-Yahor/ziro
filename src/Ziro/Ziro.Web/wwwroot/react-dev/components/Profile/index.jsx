import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Icon from '@material-ui/core/Icon';
import withStyles from '@material-ui/core/styles/withStyles';
import './profile.css'
import { isUserAuthenticated, fetchGetData, getRandomNumber } from '../../utils.js'
import EditForm from './ProfileEditForm.jsx'

const styles = theme => ({
   paper: {
      ' max-width': '900px',
      marginLeft: 'auto',
      marginRight: 'auto',
      //spacing.unit = 8
      padding: `${theme.spacing.unit * 4}px ${theme.spacing.unit * 5}px ${theme.spacing.unit * 5}px`,
   },
   ava__wrap: {
      width: '150px',
      height: '150px',
   },
   ava: {
      width: '100%',
      borderRadius: '50%',
   },
   editBtn: {
      marginTop: '10px'
   }
});


class Profile extends Component {
   constructor(props) {
      super(props);
      if (!isUserAuthenticated()) {
         this.props.history.push('/authorization');
         return;
      }
      this.state = {
         isEditFormVisible: false,
         name: null,
         lastName: null,
         email: null,
         skype: null,
         phoneNumber: null,
         position: null,
         dateOfBirth: null,
         data: null,
      };
      this.editFormSetVisibility = this.editFormSetVisibility.bind(this);
      this.successGetData = this.successGetData.bind(this);
      this.errorGetData = this.errorGetData.bind(this);
      fetchGetData('api/user/getProfile', this.successGetData, this.errorGetData);
   }

   successGetData(response){
      var data = response.data;
      if (!response.errors) {
         this.setState({
            name: data.name,
            lastName: data.lastName,
            email: data.email,
            skype: data.skype,
            phoneNumber: data.phoneNumber, 
            position: data.position.name, 
            dateOfBirth: data.dateOfBirth,
            data: data
         })
      }
   }

   errorGetData(error) {
      alert(error);
   }

   editFormSetVisibility(e) {
      e.preventDefault();
      this.setState({ isEditFormVisible: !this.state.isEditFormVisible });
   }

   logout = () => {
      this.props.history.push('/logout');
   }

   render() {
      const { classes } = this.props;
      const randomNumber = getRandomNumber(1, 5000);
      return (
         <div className="container">
            <Paper className={`${classes.paper} profile__wrap`}>
               <div className="profile__image-block col">
                  <div className={classes.ava__wrap}>
                     <img className={classes.ava} src={`/api/user/getAvatar?t=${randomNumber}`} alt="user avatar" />
                  </div>
                  <Button variant="contained" color="primary" className={`${classes.editBtn} profile-edit__btn`} onClick={this.editFormSetVisibility}>
                  {this.state.isEditFormVisible ? 'Отмена' : 'Редактировать'}
                    <Icon>edit_icon</Icon>
                  </Button>
               </div>
               <div className="profile__info-block col">
                  <Typography className="profile__name" color="textPrimary" component="h1" variant="h5">{this.state.lastName} {this.state.name}</Typography>
                  <Typography className="profile__position" color="textPrimary" component="h2" variant="h6">{this.state.position}</Typography>
                  <br />
                  <p className="personal-data">email: {this.state.email}</p>
                  <p className="personal-data">skype: {this.state.skype}</p>
                  <p className="personal-data">Номер телефона: {this.state.phoneNumber}</p>
                  <p className="personal-data">Дата рождения: {this.state.dateOfBirth}</p>

                  <p className="personal-data">Technology and skills: <span>C#, ASP.NET, DB, javascript</span></p>
                  <p className="personal-data">Current projects: <span>Ziro, Machine learning startap</span></p>
               </div>
               <div className="profile__exit col">
                  <Button variant="contained" color="primary" onClick={this.logout}>
                     Выйти
                        <Icon>open_in_new</Icon>
                  </Button>
               </div>
            </Paper>

            {this.state.isEditFormVisible ? <EditForm data={this.state.data}/> : null}

         </div>
      );
   }
}

Profile.propTypes = {
   classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Profile);