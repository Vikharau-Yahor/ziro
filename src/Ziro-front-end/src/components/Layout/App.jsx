import React, { Component } from 'react';
import './App.css';
import Content from './Content'
import Header from './Header'
import Footer from './Footer'


//App renders all web-application
class App extends Component {
  render() {
    return (
        <div className="wrapper">
          <Header/>
          <Content/>
          <Footer/>
      </div>
    );
  }
}

export default App;
