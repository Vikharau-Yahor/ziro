import React, { Component } from 'react';
import './App.css';
import Content from './Content/index.jsx'
import Header from './Header/index.jsx'
import Footer from './Footer/index.jsx'


//App renders all web-application
class App extends Component {
  render() {
    return (
        <>
          <Header/>
          <Content/>
          <Footer/>
      </>
    );
  }
}

export default App;
