import React from 'react';
import ReactDOM from 'react-dom';
import App from './components/Layout/App.jsx';
import AjaxData from './AjaxData.jsx';
import { BrowserRouter } from 'react-router-dom';

ReactDOM.render((
    <BrowserRouter>
        <AjaxData/>
        <App/>        
    </BrowserRouter>
), document.getElementById('root'));