import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom'
import Tasks from '../../Tasks/index.jsx'
import Task from '../../Task/index.jsx'
import Team from '../../Team/index.jsx'
import Authorization from '../../Authorization/index.jsx'
import Logout from '../../Logout/index.jsx'
import AdminPanel from '../../AdminPanel/index.jsx'
import Profile from '../../Profile/index.jsx'
import NotFound from '../../NotFound/index.jsx'


class Content extends Component {
    render() {
        return (
            <main>
                <Switch>
                    <Route exact path="/" component={Tasks} />
                    <Route path="/profile" component={Profile}/>
                    <Route path="/team" component={Team}/>
                    <Route path="/authorization" component={Authorization} />
					<Route path="/logout" component={Logout} />

                    <Route path="/task" component={Task} />
                    <Route path="/adminpanel" component={AdminPanel} />
                    <Route component={NotFound} />
                </Switch>
            </main>
        )
    }
}
export default Content;