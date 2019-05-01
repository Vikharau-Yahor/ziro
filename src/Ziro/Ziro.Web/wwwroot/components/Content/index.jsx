import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom'
import Home from '../Home.jsx'
import Authorization from '../Authorization/index.jsx'
import Profile from '../Profile/index.jsx'
import NotFound from '../NotFound.jsx'

class Content extends Component {
    render() {
        return (
            <main>
                <Switch>
                    <Route exact path="/" component={Home} />
                    <Route path="/profile" component={Profile}/>
                    <Route path="/authorization" component={Authorization} />

                    <Route component={NotFound} />
                </Switch>
            </main>
        )
    }
}
export default Content;