import React, { Component } from 'react';
import { Link } from "react-router-dom";

import ava from '../../../img/ava_e-v.jpg'

class Header extends Component {
    render(){
        return(
          <header>
            <div className="container">
              <h1 className="logo"><span>Z</span>IRO</h1>
              <div className="menu-wrap">
                <ul className="menu">
                {/*components in Content */}
                  <li className="menu__item">
                      <Link to ="/">Tasks</Link>
                  </li>
                  <li className="menu__item">
                      <Link to ="/team">Team</Link>
                  </li>
                  <li className="menu__item">
                      <Link to ="/authorization">Authorization</Link>
                  </li>
                </ul> 
              </div>
              <div className="profile-wrap">
                <Link to ="/profile"><img className="short-img" src={ava} alt="avatar"/></Link>
              </div>
            </div>
        </header>
        )
    }
}

export default Header;