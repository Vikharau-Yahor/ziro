import React, { Component } from 'react'
import PropTypes from 'prop-types';
import './authorization.css'
//material ui
import Button from '@material-ui/core/Button';
import Paper from '@material-ui/core/Paper';
import Avatar from '@material-ui/core/Avatar';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import FormControl from '@material-ui/core/FormControl';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Input from '@material-ui/core/Input';
import InputLabel from '@material-ui/core/InputLabel';
import Checkbox from '@material-ui/core/Checkbox';

import withStyles from '@material-ui/core/styles/withStyles';

const styles = theme => ({
    paper: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        width: 400,
        marginLeft: 'auto',
        marginRight: 'auto',
        //spacing.unit = 8
        padding: `${theme.spacing.unit * 2}px ${theme.spacing.unit * 5}px ${theme.spacing.unit * 3}px`,
    },
    avatar: {
        margin: theme.spacing.unit,
        backgroundColor: theme.palette.secondary.main,
    },
    form: {
        //width: '92%', // Fix IE 11 issue.
        //marginTop: theme.spacing.unit,
    },
    remember: {
        display: 'flex'
    },
    submit: {
        display: 'flex',
        width: '50%',        
        margin: `${theme.spacing.unit * 3}px auto 0`,
    },
});

//class Authorization extends Component {
function Authorization(props) {
    const { classes } = props;
    //render() {
    return (
        <div className="container">
            <h2>Authorization page</h2>

            <Paper className={classes.paper}>
                <Avatar className={classes.avatar}>
                    <LockOutlinedIcon />
                </Avatar>
                <Typography color="textPrimary" component="h1" variant="h5">Вход</Typography>
                <form className={`${classes.form} authorization-form`} action="">
                    <FormControl margin="normal" required fullWidth>
                        <InputLabel htmlFor="email">Email</InputLabel>
                        <Input id="email" type="email" name="email" autoComplete="email" autoFocus />
                    </FormControl>
                    <FormControl margin="normal" required fullWidth>
                        <InputLabel htmlFor="password">Пароль</InputLabel>
                        <Input name="password" type="password" id="password" autoComplete="current-password" />
                    </FormControl>
                    <FormControlLabel className={classes.remember}
                        control={<Checkbox value="remember" color="primary" />}
                        label="Запомнить"
                    />
                    <Button
                        type="submit"
                        variant="contained"
                        color="primary"
                        className={classes.submit}
                    >Войти</Button>
                </form>
            </Paper>
        </div>

    );
    //}
}
Authorization.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Authorization);