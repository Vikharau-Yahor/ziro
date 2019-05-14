import React, { Component } from 'react'
import { Link } from "react-router-dom"
import PropTypes from 'prop-types'
import Paper from '@material-ui/core/Paper'
//import Typography from '@material-ui/core/Typography'
import Button from '@material-ui/core/Button'
import AddIcon from '@material-ui/icons/Add';
import TextField from '@material-ui/core/TextField';
import withStyles from '@material-ui/core/styles/withStyles'
import { green } from '@material-ui/core/colors';
import './projects.css'
import { isUserAuthenticated, fetchGetData } from '../../utils.js'

const styles = theme => ({
   paper: {
      'max-width': '900px',
      marginLeft: 'auto',
      marginRight: 'auto',
      padding: `${theme.spacing.unit * 4}px ${theme.spacing.unit * 5}px ${theme.spacing.unit * 5}px`,
   },
   search: {
      width: '60%',
   },
   addBtn: {
      color: '#fff',
      backgroundColor: green[600],
      '&:hover': {
         backgroundColor: green[400],
      },
   }
});

class Projects extends Component {
   constructor(props) {
      super(props);
      this.state = {
         projects: [],
         isCurRoleAdmin: false,
      }
      if (!isUserAuthenticated()) {
         this.props.history.push('/authorization');
         return;
      }
      fetchGetData('api/project/getCurrentProjectsInfos', this.successGetData, this.errorGetData);
   }

   successGetData = (response) => {
      var projects = response.data.projects;
      if (!response.errors) {
         this.setState({
            projects: projects
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
            <div className="search-block">
               <TextField
                  id="outlined-search"
                  label="Поиск проекта..."
                  type="search"
                  className={classes.search}
                  margin="normal"
                  variant="outlined"
               />
               {this.state.isCurRoleAdmin ?
                  <div className="buttons-block">
                     <Button variant="contained" className={classes.addBtn}>
                        <AddIcon />
                        Создать проект
                     </Button>
                  </div>
                  : null}
            </div>

            <Paper className="projects-block">
               <div className="projects-header">
                  <div className="item__col">
                     <p>Название</p>
                  </div>
                  <div className="item__col">
                     <p>Краткое название</p>
                  </div>
                  <div className="item__col">
                     <p>Описание</p>
                  </div>
                  <div className="item__col">
                     <p>Текущие задачи</p>
                  </div>
                  <div className="item__col">
                     <p>Человек на проекте</p>
                  </div>
               </div>

               <div className="projects-list">
                  {this.state.projects.map((proj, index) =>
                     <Link to={`/project/${proj.shortName}`} className="project__item" key={proj.id}>
                        {/* <div className="project__item"> */}
                        <div className="item__col">
                           <p className="project__title">{proj.name}</p>
                        </div>
                        <div className="item__col">
                           <p className="project__short-title">{proj.shortName}</p>
                        </div>
                        <div className="item__col">
                           <p className="project__description">{proj.description}</p>
                        </div>
                        <div className="item__col">
                           <p className="project__count">{proj.nonClosedTasksCount}</p>
                        </div>
                        <div className="item__col">
                           <p className="project__count">{proj.totalUsersCount}</p>
                        </div>
                        {/* </div> */}
                     </Link>
                  )}
               </div>

            </Paper>
         </div>
      )
   }
}

Projects.propTypes = {
   classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Projects);