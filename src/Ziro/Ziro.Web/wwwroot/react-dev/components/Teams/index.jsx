import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import withStyles from '@material-ui/core/styles/withStyles';
import './teams.css'
import { isUserAuthenticated } from '../../utils.js'

const styles = theme => ({
    paper: {
        overflowX: 'auto',
    }
});

class Teams extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: {
                members: []
            }
        }
        if (!isUserAuthenticated()) {
            this.props.history.push('/authorization');
            return;
        }
        fetchGetData('api/user/getTeamMembers', this.successGetData, this.errorGetData);
    }

    successGetData = (response) => {
        var res_data = response.data;
        if (!response.errors) {
            this.setState({
                data: res_data
            })
        }
    }

    errorGetData = (error) => {
        alert(error);
    }

    render() {
        const { classes } = this.props;
        return (
            <div className="container">
                <Paper className="teams-block">
                    <div className="team-section">
                        {this.state.data.map((proj, index) =>
                        <Typography component="h1" variant="h4" className="project__name" key={index}>{proj.projectName}</Typography>
                        )}
                        <div className="team-block">
                            {this.state.data.members.map((member, index) =>
                            <Card className={`${classes.card} team__member`} key={index}>
                                <CardMedia
                                    component="img"
                                    alt="team member"
                                    className={classes.media}
                                    height="160"
                                    image={`/api/user/getAvatar`}
                                />
                                <CardContent>
                                    <Typography component="h2" variant="h5">
                                        {member.lastName} {member.name}
                                    </Typography>
                                    <Typography variant="body2">
                                        {member.position}
                                    </Typography>
                                    <Typography variant="body1">
                                        {member.email}
                                    </Typography>
                                    <Typography variant="body1">
                                        {member.phoneNumber}
                                    </Typography>
                                </CardContent>
                            </Card>
                            )}
                        </div>
                    </div>
                </Paper>
            </div>
        )
    }
}

Teams.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Teams)
