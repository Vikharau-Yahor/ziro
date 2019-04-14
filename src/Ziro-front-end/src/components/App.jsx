import React, { Component } from 'react';
import './App.css';
import Nav from './Nav'
//import Button from '@material-ui/core/Button';


class App extends Component {
  render() {
    return (
      <div className="wrapper">
        <header>
          <div className="container">
            <h1 className="logo"><span>Z</span>IRO</h1>
          </div>
          <Nav />
        </header>
        
        <footer>
          <div className="container">
            <p>Ziro - 2019 all rules saved</p>
          </div>
        </footer>
      </div>
    );
  }
}

export default App;
