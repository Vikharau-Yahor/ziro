import React, { Component } from 'react';
import './App.css';
import Content from './Content/index.jsx'
import Header from './Header/index.jsx'
import Footer from './Footer/index.jsx'
import CookieEventManager from '../../events.js'

//App renders all web-application
class App extends Component {
	constructor(props) {
		super(props);
		CookieEventManager.initEvents();
	}

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
