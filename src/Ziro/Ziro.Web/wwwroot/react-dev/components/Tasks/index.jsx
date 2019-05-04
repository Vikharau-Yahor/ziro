import React, { Component } from 'react';
import { Link } from "react-router-dom";

import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Icon from '@material-ui/core/Icon';
import AddIcon from '@material-ui/icons/Add';
import SvgIcon from '@material-ui/core/SvgIcon';

import withStyles from '@material-ui/core/styles/withStyles';

import './tasks.css'

const styles = theme => ({
    paper: {
        overflowX: 'auto',        
    }    
});


const data = [ {
        'id': 'C-11',
        'status_id': 's0',
        'priority': 'normal',
        'name': 'fix color submit button'
    },
    {
        'id': 'C-21',
        'status_id': 's1',
        'priority': 'critical',
        'name': 'Need to fix links in the DB' 
    },
    {
        'id': 'C-31',
        'status_id': 's2', 
        'priority': 'normal',
        'name': 'change information on home page' 
    }
  ]

// class Tasks extends Component {
//     render() {
//         const { classes } = this.props;
//         return (
//             <div className="container">
//                 <Typography color="textPrimary" component="h1" variant="h4">Current tasks</Typography>
//                 <Paper className={classes.paper}>
//                     <TasksTable data={data} />
//                 </Paper>
//             </div>
//         )
//     }
// }

class Tasks extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: data
        }
    }

        render() {
        const { classes } = this.props;
        return (
            <div className="container">
                <div className="tasks__block">
                    {data.map((elem, index) =>
                    <Link to ="/task" className="tasks__item" key={index}>
                        <div className="item__header">
                            <div className={`${elem.status_id} task__status-icon`}>{elem.status}</div>
                            <div className="task__id">{elem.id}</div>
                        </div>
                        {/* <div className="item__description"> */}
                        <p className="item__name">{elem.name}</p>
                        {/* </div> */}
                    </Link>
                    )}
                </div>
            </div>
        )
    }
}



Tasks.propTypes = {
    classes: PropTypes.object.isRequired,
  };

export default withStyles(styles)(Tasks)