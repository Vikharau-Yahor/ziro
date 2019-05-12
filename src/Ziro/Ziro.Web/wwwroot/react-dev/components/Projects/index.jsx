import React, { Component } from 'react'
import PropTypes from 'prop-types'
import Paper from '@material-ui/core/Paper'
//import Typography from '@material-ui/core/Typography'
//import Button from '@material-ui/core/Button'
import TextField from '@material-ui/core/TextField';
import withStyles from '@material-ui/core/styles/withStyles'
import './projects.css'
import { isUserAuthenticated, fetchGetData, getRandomNumber } from '../../utils.js'

const styles = theme => ({
   paper: {
      'max-width': '900px',
      marginLeft: 'auto',
      marginRight: 'auto',
      padding: `${theme.spacing.unit * 4}px ${theme.spacing.unit * 5}px ${theme.spacing.unit * 5}px`,
   },
   search: {
      width: '60%',
      marginBottom: '40px'
   }
});

class Projects extends Component {
   render() {
      const { classes } = this.props;
      return (
         <div className="container">

            <TextField
               id="outlined-search"
               label="Поиск проекта..."
               type="search"
               className={classes.search}
               margin="normal"
               variant="outlined"
            />

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
                     <p>Человек на проекте</p>
                  </div>
                  <div className="item__col">
                     <p>Текущие задачи</p>
                  </div>
               </div>
               <div className="projects-list">
                  <div className="project__item">
                     <div className="item__col">
                        <p className="project__title">Twitter</p>
                     </div>
                     <div className="item__col">
                        <p className="project__short-title">TWIT</p>
                     </div>
                     <div className="item__col">
                        <p className="project__description">Lorem ipsum sit amet dolor, lorem ipsum dolor sit amet</p>
                     </div>
                     <div className="item__col">
                        <p className="project__short-title">17</p>
                     </div>
                     <div className="item__col">
                        <p className="project__short-title">10</p>
                     </div>
                  </div>
                  {/*  */}
                  <div className="project__item">
                     <div className="item__col">
                        <p className="project__title">Twitter</p>
                     </div>
                     <div className="item__col">
                        <p className="project__short-title">TWIT</p>
                     </div>
                     <div className="item__col">
                        <p className="project__description">Lorem ipsum sit amet dolor, lorem ipsum dolor sit amet</p>
                     </div>
                     <div className="item__col">
                        <p className="project__short-title">17</p>
                     </div>
                     <div className="item__col">
                        <p className="project__short-title">10</p>
                     </div>
                  </div>
                  {/*  */}
                  <div className="project__item">
                     <div className="item__col">
                        <p className="project__title">Twitter</p>
                     </div>
                     <div className="item__col">
                        <p className="project__short-title">TWIT</p>
                     </div>
                     <div className="item__col">
                        <p className="project__description">Lorem ipsum sit amet dolor, lorem ipsum dolor sit amet</p>
                     </div>
                     <div className="item__col">
                        <p className="project__short-title">17</p>
                     </div>
                     <div className="item__col">
                        <p className="project__short-title">10</p>
                     </div>
                  </div>
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