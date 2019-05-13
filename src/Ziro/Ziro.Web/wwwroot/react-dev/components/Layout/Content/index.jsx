import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom'
import Tasks from '../../Tasks/index.jsx'
import Task from '../../Task/index.jsx'
import Projects from '../../Projects/index.jsx'
import Project from '../../Project/index.jsx'
import Teams from '../../Teams/index.jsx'
import Profile from '../../Profile/index.jsx'
import Authorization from '../../Authorization/index.jsx'
import Logout from '../../Logout/index.jsx'
import Users from '../../AdminPanel/Users.jsx'
import NotFound from '../../NotFound/index.jsx'
import { isCurRoleUser, isCurRoleAdmin } from '../../../utils.js'
import CookieEventManager from '../../../events.js'

class Content extends Component {
   constructor(props) {
      super(props);
      this.state = {
         isCurRoleUser: isCurRoleUser()
      };
      CookieEventManager.addCookieChangedHandler(this.setHomeComponent);
   }
   setHomeComponent = () => {
      this.setState({ isCurRoleUser: isCurRoleUser() });
   }
   render() {
      return (
         <main>
            <Switch>
               {this.state.isCurRoleUser ? <Route exact path="/" component={Tasks} />
                  : <Route exact path="/" component={Projects} />
               }
               <Route exact path="/" component={Tasks} />
               <Route path="/task/:task_number" component={Task} />
               <Route path="/projects" component={Projects} />
               <Route path="/project/:short_name" component={Project} />
               <Route path="/teams" component={Teams} />

               <Route path="/profile" component={Profile} />
               <Route path="/authorization" component={Authorization} />
               <Route path="/logout" component={Logout} />               
               <Route path="/users" component={Users} />
               <Route component={NotFound} />
            </Switch>
         </main>
      )
   }
}
export default Content;