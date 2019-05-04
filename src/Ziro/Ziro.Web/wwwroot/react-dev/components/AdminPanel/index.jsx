import React, { Component } from 'react';
import PropTypes from 'prop-types';
import FormControl from '@material-ui/core/FormControl';
import Input from '@material-ui/core/Input';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import withStyles from '@material-ui/core/styles/withStyles';
import './adminpanel.css'

const styles = theme => ({
    avatar: {
        margin: theme.spacing.unit,
        backgroundColor: theme.palette.secondary.main,
    },
});

class AdminPanel extends Component {
    render() {
        const { classes } = this.props;
        return (
            <div className="container">
                <Paper className={classes.paper}>
                    <Typography component="h1" variant="h5">Добавление ногово сотрудника</Typography>
                    <form className="add-employee-form" action="">
                        <FormControl fullWidth={true}>
                            <Input placeholder="Имя" required />
                        </FormControl>
                        <FormControl fullWidth={true}>
                            <Input placeholder="Фамилия" required />
                        </FormControl>
                        <FormControl fullWidth={true}>
                            <Input placeholder="Отчество" />
                        </FormControl>
                        <FormControl fullWidth={true}>
                            <Input placeholder="Страна проживания" required />
                        </FormControl>
                        <FormControl fullWidth={true}>
                            <Input placeholder="Город проживания" required />
                        </FormControl>
                        <FormControl fullWidth={true}>
                            <Input placeholder="Дата рождения" required />
                        </FormControl>
                        <Button type="submit" variant="contained" color="primary">Сохранить</Button>
                    </form>
                </Paper>
            </div>
        )
    }
}

AdminPanel.propTypes = {
    classes: PropTypes.object.isRequired,
};
export default withStyles(styles)(AdminPanel);