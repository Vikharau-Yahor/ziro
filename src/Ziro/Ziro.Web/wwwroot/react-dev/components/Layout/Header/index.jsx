import React, { Component } from 'react';
import { Link } from "react-router-dom";
import { isUserAuthenticated, isCurRoleUser, isCurRoleAdmin } from '../../../utils.js'
import CookieEventManager from '../../../events.js'
import { getRandomNumber } from '../../../utils.js';

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
      const randomNumber = getRandomNumber(1, 5000);
      return (
         <React.Fragment>
            <div className="menu-wrap">
               <ul className="menu">
                  <li className="menu__item" >
                     <Link to="/" activeStyle={{ color: rgb(63, 125, 219) }}>Задачи</Link>
                  </li>
                  <li className="menu__item">
                     <Link to="/projects" activeStyle={{ color: rgb(63, 125, 219) }}>Проекты</Link>
                  </li>
                  <li className="menu__item">
                     <Link to="/teams" activeStyle={{ color: rgb(63, 125, 219) }}>Команды</Link>
                  </li>
               </ul>
            </div>
            <div className="profile-wrap">
               <Link to="/profile"><img className="short-img" src={`/api/user/getAvatar?t=${randomNumber}`} alt="avatar" /></Link>
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
                  <Link to="/" activeStyle={{ color: rgb(63, 125, 219) }}>Проекты</Link>
               </li>
               <li className="menu__item">
                  <Link to="/users" activeStyle={{ color: rgb(63, 125, 219) }}>Пользователи</Link>
               </li>
               <li className="menu__item">
                  <Link to="/logout">Выйти</Link>
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
                  <Link to="/authorization" activeStyle={{ color: rgb(63, 125, 219) }}>Авторизация</Link>
               </li>
            </ul>
         </div>
      )
   }
}

export default Header;