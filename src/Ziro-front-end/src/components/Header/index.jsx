import React, { Component } from 'react';
import { Link } from "react-router-dom";

class Header extends Component {
    render(){
        return(
            <header>
          <div className="container">
            <h1 className="logo"><span>Z</span>IRO</h1>
            <ul className="menu">
            {/*components in Content */}
              <li>
                  <Link to ="/">Home</Link>
              </li>
              <li>
                  <Link to ="/authorization">Authorization</Link>
              </li>
              <li>
                  <Link to ="/profile">Profile</Link>
              </li>
            </ul>          
          </div>
        </header>
        )
    }
}

export default Header;