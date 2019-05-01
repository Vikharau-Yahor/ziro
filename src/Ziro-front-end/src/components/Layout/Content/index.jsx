import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom'
import Tasks from '../../Tasks'
import Task from '../../Task'
import Team from '../../Team'
import Authorization from '../../Authorization'
import Profile from '../../Profile'
import NotFound from '../../NotFound'

class Content extends Component {
    render() {
        return (
            <main>
                <Switch>
                    <Route exact path="/" component={Tasks} />
                    <Route path="/profile" component={Profile}/>
                    <Route path="/team" component={Team}/>
                    <Route path="/authorization" component={Authorization} />

                    <Route path="/task" component={Task} />

                    <Route component={NotFound} />
                </Switch>
            </main>
        )
    }
}
export default Content;