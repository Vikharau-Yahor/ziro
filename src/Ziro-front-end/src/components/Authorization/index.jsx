import React, { Component } from 'react'
import './authorization.css'
//material ui
import PropTypes from 'prop-types';
import Paper from '@material-ui/core/Paper';
import Button from '@material-ui/core/Button';
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
        marginTop: '5%',
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
    errorMessage: {
        color: '#f00',
        transition: 'all .5s ease',
        fontSize: '.875em',
        opacity: 0
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

class Authorization extends Component {
    // constructor(props) {
    //     super(props)
    // }    
    render() {
        const { classes } = this.props;
        return (
            <div className="container">
                <Paper className={classes.paper}>
                    <Avatar className={classes.avatar}>
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography color="textPrimary" component="h1" variant="h5">Вход</Typography>
                    <form className={`${classes.form} authorization-form`} action="">
                        <FormControl error margin="normal" required fullWidth>                            
                            <InputLabel htmlFor="email">Email</InputLabel>
                            <Input id="email" type="email" name="email" autoComplete="email" autoFocus />
                            <Typography className={classes.errorMessage} component="span" variant="p">error</Typography>
                        </FormControl>
                        <FormControl margin="normal" required fullWidth>
                            <InputLabel htmlFor="password">Пароль</InputLabel>
                            <Input name="password" type="password" id="password" autoComplete="current-password" />
                            <Typography className={classes.errorMessage} component="span" variant="p">error</Typography>
                        </FormControl>
                        <FormControlLabel className={classes.remember}
                            control={<Checkbox value="remember" color="primary" />}
                            label="Запомнить"
                        />                        
                        <Button type="submit" variant="contained" color="primary" className={classes.submit}>Войти</Button>
                    </form>
                </Paper>
            </div>
        )
    }
}

Authorization.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Authorization);