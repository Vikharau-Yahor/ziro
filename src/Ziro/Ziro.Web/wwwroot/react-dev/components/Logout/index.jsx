import React, { Component } from 'react'
import { fetchGetData } from '../../utils.js';
import CookieEventManager  from '../../events.js'

class Logout extends Component {
   constructor(props) {
      super(props);
	  this.errorLogout = this.errorLogout.bind(this);
	  this.successLogout = this.successLogout.bind(this);
	  fetchGetData('api/account/logout', this.successLogout, this.errorLogout);
   }

	successLogout(response) {		
		this.props.history.push('/authorization');
		CookieEventManager.invokeCookieChanged();	
	}

	errorLogout(error) {
      alert(error);
   }

   render() {
	   return (null);
   }
}

export default Logout;