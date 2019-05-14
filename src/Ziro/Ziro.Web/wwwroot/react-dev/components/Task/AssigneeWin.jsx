import React, { Component } from 'react';
import PropTypes from 'prop-types';
//import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import DialogTitle from '@material-ui/core/DialogTitle';
import DialogContent from '@material-ui/core/DialogContent';
import DialogActions from '@material-ui/core/DialogActions';
import Dialog from '@material-ui/core/Dialog';
import RadioGroup from '@material-ui/core/RadioGroup';
import Radio from '@material-ui/core/Radio';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import withStyles from '@material-ui/core/styles/withStyles';
import { fetchGetData } from '../../utils.js'

const styles = theme => ({

});

class AssigneeWin extends Component {
    constructor(props) {
        super();
        this.state = {
            value: props.value,
            selectedTeamMember: ''
        };
        this.teamMembers = [];
    }

    successGetTeamMembers = (response) => {
        let arr = response.data;
        let teamMembers = [];
        for (let key in arr) {
            teamMembers.push({
              val: key,
              text: arr[key]
           })
        }
        if (!response.errors) {
           this.teamMembers = teamMembers;
        }
    }
    errorGetData = (error) => {
        alert(error);
    }
    getFormData = () => {
        fetchGetData('api/user/getTeamMembers', this.successGetTeamMembers, this.errorGetData);
    }

    // TODO
    componentWillReceiveProps(nextProps) {
        if (nextProps.value !== this.props.value) {
            this.setState({ value: nextProps.value });
        }
    }

    handleEntering = () => {
        this.radioGroupRef.focus();
    };

    handleCancel = () => {
        this.props.onClose(this.props.value);
    };

    handleOk = () => {
        this.props.onClose(this.state.value);
    };

    handleChange = (event, value) => {
        this.setState({ value });
    };

    render() {
        const { value } = this.props;
        const {teamMembers} = this.teamMembers;
        return (
            <Dialog
                maxWidth="xs"
                onEntering={this.handleEntering}
            //aria-labelledby="confirmation-dialog-title"
            >
                <DialogTitle id="confirmation-dialog-title">Назначить задачу</DialogTitle>
                <DialogContent>
                    <RadioGroup
                        ref={ref => {
                            this.radioGroupRef = ref;
                        }}
                        aria-label="Ringtone"
                        name="ringtone"
                        value={this.state.value}
                        onChange={this.handleChange}
                    >
                        {teamMembers.map((assignee, index) =>
                            <FormControlLabel
                                value={assignee}
                                key={index}
                                control={<Radio />}
                                label={assignee}
                            />
                        )}
                    </RadioGroup>
                </DialogContent>
                <DialogActions>
                    <Button onClick={this.handleCancel} color="primary">
                        Cancel
                    </Button>
                    <Button onClick={this.handleOk} color="primary">
                        Ok
                    </Button>
                </DialogActions>
            </Dialog>
        )
    }
}

AssigneeWin.propTypes = {
    onClose: PropTypes.func,
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(AssigneeWin)