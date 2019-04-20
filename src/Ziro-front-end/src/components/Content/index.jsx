import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom'
import Home from '../Home'
import Authorization from '../Authorization'
import Profile from '../Profile'
import NotFound from '../NotFound'

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