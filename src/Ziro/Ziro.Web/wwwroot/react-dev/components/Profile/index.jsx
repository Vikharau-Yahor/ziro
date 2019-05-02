import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Icon from '@material-ui/core/Icon';
import AddIcon from '@material-ui/icons/Add';
import SvgIcon from '@material-ui/core/SvgIcon';

import { blue, red, yellow, purple, green } from '@material-ui/core/colors';
import withStyles from '@material-ui/core/styles/withStyles';
import ava from '../../img/ava_e-v.jpg'
import './profile.css'

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
    customCss: {
        // color: theme.palette.getContrastText(purple[300]),
        color: '#fff',
        backgroundColor: blue[700],
        '&:hover': {
          backgroundColor: blue[400],
        },
        padding: '6px 12px',
        margin: '10px 0'
    }
});


class Profile extends Component {
    //constructor(props) {
        //super(props)
    //}    
    render() {
        const { classes } = this.props;
        return (
            <div className="container">
            <Paper className={`${classes.paper} profile__wrap`}>
                <div className="profile__image-block col">
                    <div className={classes.ava__wrap}>
                        <img className={classes.ava} src={ava} alt="user"/>
                    </div>
                    <Button variant="contained" className={`${classes.customCss} profile__btn`}>Редактировать
                    <Icon>edit_icon</Icon>                        
                    </Button>
                </div>
                <div className="profile__info-block col">
                    <Typography className="profile__name" color="textPrimary" component="p" variant="h5">Вихарев Егор</Typography>
                    <Typography className="profile__position" color="textPrimary" component="p" variant="p">ASP.NET developer</Typography>
                    <br/>
                    <Typography className="profile__skills" color="textPrimary" component="p" variant="p">Technology and skills: <span>C#, ASP.NET, DB, javascript</span></Typography>
                    <br/>
                    <Typography className="profile__projects" color="textPrimary" component="p" variant="p">Current projects: <span>Ziro, Machine learning startap</span></Typography>
                </div>
                <div className="profile__exit col">
                    <Button variant="contained" className={`${classes.customCss} profile__btn`}>Выйти
                        <Icon>open_in_new</Icon>                        
                    </Button>
                </div>
            </Paper>
            </div>
        );
      }
}

Profile.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Profile);