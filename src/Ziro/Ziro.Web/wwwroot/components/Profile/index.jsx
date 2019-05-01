import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';

import withStyles from '@material-ui/core/styles/withStyles';
//import ava from '../../img/ava_e-v.jpg'


const styles = theme => ({
    paper: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        width: '80%',
        marginLeft: 'auto',
        marginRight: 'auto',
        //spacing.unit = 8
        padding: `${theme.spacing.unit * 2}px ${theme.spacing.unit * 5}px ${theme.spacing.unit * 3}px`,
    },
    ava__wrap: {
        width: '150px',
        height: '150px',
    },
    ava: {
        width: '100%',
        borderRadius: '50%',
    },
});
var ava_src = "img/ava_e-v.jpg";

class Profile extends Component {
    //constructor(props) {
        //super(props)
    //}    
    render() {
        const { classes } = this.props;
        return (
            <div className="container">
            <Paper className={classes.paper}>
                <div className="profile__image-block col">
                    <div className={classes.ava__wrap}>
						<img className={classes.ava} src={ava_src} alt="user"/>
                    </div>
                </div>
                <div className="profile__info-block col">
                    <Typography color="textPrimary" component="p" variant="h5">Вихарев Егор</Typography>
                    <Typography color="textPrimary" component="p" variant="p">ASP.NET developer</Typography>
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