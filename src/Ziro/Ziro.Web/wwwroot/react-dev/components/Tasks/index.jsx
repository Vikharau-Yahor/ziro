import React, { Component } from 'react';
import { Link } from "react-router-dom";
import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
import Icon from '@material-ui/core/Icon';

import withStyles from '@material-ui/core/styles/withStyles';
import './tasks.css'
import { fetchGetData, isUserAuthenticated } from '../../utils.js'

const styles = theme => ({
   paper: {
      overflowX: 'auto',
   }
});


class Tasks extends Component {
   constructor(props) {
      super(props);
      this.state = {
         tasks: []
      }
      if (!isUserAuthenticated()) {
         this.props.history.push('/authorization');
         return;
      }
      fetchGetData('api/task/getCurrentTasks', this.successGetData, this.errorGetData);
   }

   successGetData = (response) => {
      //var responseText = JSON.stringify(response.data.tasks);
      //alert(responseText);
      var tasks = response.data.tasks;
      if (!response.errors) {
         this.setState({
            tasks: tasks
         })
      }
   }

   errorGetData = (error) => {
      alert(error);
   }

   render() {
      //const { classes } = this.props;
      return (
         <div className="container flex">
            <div className="filter__block">
               <p>Фильтры</p>
               <Icon>filter_list</Icon>
            </div>
            <Paper className="tasks__block">
               {this.state.tasks.map((elem, index) =>
                  <Link to={`/task/${elem.number}`} params={{ id: elem.id }} className="tasks__item" key={index}>
                     <div className="item__header">                        
                        <div className="item__number">{elem.number}</div>
                        <p className="item__name">{elem.title}</p>
                     </div>
                     <div className="item__state">                        
                        <span className={`p${elem.priorityNum} item__priority-icon`}></span>
                        <span className={`item__status item__status_s${elem.statusNum}`}>{elem.status}</span>
                        <span className="item__type">{elem.type}</span>                                                
                     </div>
                     <p className="item__description">{elem.description}</p>
                  </Link>
               )}
            </Paper>
         </div>
      )
   }
}

Tasks.propTypes = {
   classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Tasks)