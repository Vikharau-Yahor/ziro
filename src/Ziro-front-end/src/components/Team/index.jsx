import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';

import withStyles from '@material-ui/core/styles/withStyles';
import './team.css'


const styles = theme => ({
    paper: {
        overflowX: 'auto',        
    }    
});

class Team extends Component {
    render(){
        const { classes } = this.props;
        return(
            <div className="container">
                <div className="team-block">
                    <Paper className={`${classes.paper} team__item`}>
                        {/* photo */}
                        <Typography className="profile__name" color="textPrimary" component="p" variant="h5">Вихарев Егор</Typography>
                        <Typography className="profile__position" color="textPrimary" component="p" variant="p">ASP.NET developer</Typography>
                    </Paper>
                    <Paper className={`${classes.paper} team__item`}>
                        {/* photo */}
                        <Typography className="profile__name" color="textPrimary" component="p" variant="h5">Вихарев Егор</Typography>
                        <Typography className="profile__position" color="textPrimary" component="p" variant="p">ASP.NET developer</Typography>
                    </Paper>
                    <Paper className={`${classes.paper} team__item`}>
                        {/* photo */}
                        <Typography className="profile__name" color="textPrimary" component="p" variant="h5">Вихарев Егор</Typography>
                        <Typography className="profile__position" color="textPrimary" component="p" variant="p">ASP.NET developer</Typography>
                    </Paper>
                </div>
            </div>
        )
    }
}

Team.propTypes = {
    classes: PropTypes.object.isRequired,
  };

export default withStyles(styles)(Team)
