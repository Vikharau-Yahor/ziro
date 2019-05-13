import React, { Component } from 'react'
import PropTypes from 'prop-types'
import Paper from '@material-ui/core/Paper'
import Typography from '@material-ui/core/Typography'
import Button from '@material-ui/core/Button'
import CloudUploadIcon from '@material-ui/icons/CloudUpload';
//import TextField from '@material-ui/core/TextField';
//import DialogTitle from '@material-ui/core/DialogTitle';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import { DropzoneArea } from 'material-ui-dropzone'
import { green } from '@material-ui/core/colors';
import withStyles from '@material-ui/core/styles/withStyles'
import './project.css'
import { isUserAuthenticated, fetchGetData } from '../../utils.js'

const styles = theme => ({
   paper: {
      'max-width': '900px',
      marginLeft: 'auto',
      marginRight: 'auto',
      padding: `${theme.spacing.unit * 4}px ${theme.spacing.unit * 5}px ${theme.spacing.unit * 5}px`,
   },
   addBtn: {
      color: '#fff',
      backgroundColor: green[600],
      '&:hover': {
         backgroundColor: green[400],
      },
   }
});

class Upload extends Component {
   constructor(props) {
      super(props)
      this.state = {
         files: [],
      }
   }
   handleUpload(files) {
      this.setState({
         files: files
      });
   }
   render() {
      return (
         <Dialog
            open={this.props.open}
            onEntered={this.getFormData}
            aria-labelledby="dialog-title"
            maxWidth="sm"
         >
            <DialogContent className="upload__wrap">
               <Typography className="upload__text" component="h6" variant="h6">Прикрепить файлы</Typography>
               <Typography className="upload__tip" component="span" variant="h6">Перетяните файл сюда или кликните</Typography>
               <DropzoneArea
                  onChange={this.handleUpload.bind(this)}
               />

               <DialogActions>
                  <Button onClick={this.props.handleClose} variant="contained" color="primary" className="upload-cancel-btn">
                     Отмена
                           </Button>
                  <Button onClick={this.props.handleClose} variant="contained" color="primary">
                     Добавить
                           </Button>
               </DialogActions>
            </DialogContent>
         </Dialog>
      )
   }
}


class Project extends Component {
   constructor(props) {
      super(props);
      this.state = {
         project: [],
         open: false
      }
      if (!isUserAuthenticated()) {
         this.props.history.push('/authorization');
         return;
      }
      //fetchGetData('api/project/getCurrentProjectsInfos', this.successGetData, this.errorGetData);
   }

   handleClickOpen = () => {
      this.setState({
         open: true,
      });
   };

   handleClose = () => {
      this.setState({ open: false });
   };

   //    successGetData = (response) => {
   //       var project = response.data.project;
   //       if (!response.errors) {
   //          this.setState({
   //             project: project
   //          })
   //       }
   //    }

   //    errorGetData = (error) => {
   //       alert(error);
   //    }

   render() {
      const { classes } = this.props;
      return (
         <div className="container">
            <Paper className="project-block">
               <h1 className="project__title"><span className="project__short-name">TWIT</span>Twitter</h1>
               <div className="project__section project__details-block">
                  <h2 className="section__title">Детали</h2>
                  <p className="task__status"><span className="key">Открытых задач:</span> <span className="value">11</span></p>
                  <p className="task__type"><span className="key">Закрытых задач:</span> <span className="value">12</span></p>
                  <p className="task__priority"><span className="key">Человек на проекте:</span> <span className="value">13</span></p>
               </div>
               <div className="project__section project__description-block">
                  <h2 className="section__title">Описание</h2>
                  <p className="task__description">
                     Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum
                        </p>
               </div>
               <div className="project__section project__doc-block">
                  <h2 className="section__title">Документы</h2>
                  <div className="project__upload-doc-block">
                     <Button variant="contained" className={classes.addBtn} onClick={this.handleClickOpen}>
                        Добавить документ
                                <CloudUploadIcon />
                     </Button>

                     <Upload
                        open={this.state.open}
                        handleClose={this.handleClose}
                     />
                  </div>
                  <div className="project__current-docs">
                     <div className="doc-item">hfwuhf</div>
                     <div className="doc-item">hfwuhf</div>
                     <div className="doc-item">hfwuhf</div>
                  </div>
               </div>
            </Paper>
         </div>
      )
   }
}

Project.propTypes = {
   classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Project);