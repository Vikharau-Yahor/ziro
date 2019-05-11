import React, { Component } from 'react';
import { Link } from "react-router-dom";

import ava from '../../../img/ava_e-v.jpg'
import { isUserAuthenticated, isCurRoleUser, isCurRoleAdmin } from '../../../utils.js'
import CookieEventManager from '../../../events.js'

class Header extends Component {
   constructor(props) {
      super(props);
      this.state = {
         isCurUserLogged: isUserAuthenticated(),
         isCurRoleUser: isCurRoleUser(),
         isCurRoleAdmin: isCurRoleAdmin()
      };
      this.headerMenuUpdate = this.headerMenuUpdate.bind(this);
      CookieEventManager.addCookieChangedHandler(this.headerMenuUpdate);
   }
   headerMenuUpdate() {
      this.setState({ isCurUserLogged: isUserAuthenticated() });
      this.setState({ isCurRoleUser: isCurRoleUser() });
      this.setState({ isCurRoleAdmin: isCurRoleAdmin() });
   }
   render() {
      return (
         <header>
            <div className="container">
               <h1 className="logo"><span>Z</span>IRO</h1>
               {/*components in Content */}
               {this.state.isCurRoleUser ? <UserMenu /> : null}
               {this.state.isCurRoleAdmin ? <AdminMenu /> : null}
               {!this.state.isCurUserLogged ? <LoginMenu /> : null}
            </div>
         </header>
      )
   }
}

class UserMenu extends Component {
   render() {
      return (
         <React.Fragment>
            <div className="menu-wrap">
               <ul className="menu">
                  <li className="menu__item" >
                     <Link to="/">Tasks</Link>
                  </li>
                  <li className="menu__item">
                     <Link to="/team">Team</Link>
                  </li>
               </ul>
            </div>
            <div className="profile-wrap">
               <Link to="/profile"><img className="short-img" src={ava} alt="avatar" /></Link>
            </div>
         </React.Fragment>
      )
   }
}

class AdminMenu extends Component {
   render() {
      return (
         <div className="menu-wrap">
            <ul className="menu">
               <li className="menu__item">
                  <Link to="/adminpanel">Adminka</Link>
               </li>
            </ul>
         </div>
      )
   }
}

class LoginMenu extends Component {
   render() {
      return (
         <div className="menu-wrap">
            <ul className="menu">
               <li className="menu__item">
                  <Link to="/authorization">Authorization</Link>
               </li>
            </ul>
         </div>
      )
   }
}

export default Header;