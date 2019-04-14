import React,{Component} from 'react'
import { BrowserRouter, Route, Link } from "react-router-dom";
//import createBrowserHistory from 'history/createBrowserHistory'
import { createBrowserHistory } from 'history';
import Authorization from '../Authorization'
import Home from '../Home'

const history = createBrowserHistory();

const About = () => (
    <div>
        <h2>About</h2>
    </div>
)

class Nav extends Component {
    render() {
        return (
            <BrowserRouter history={history}>
                    <ul className="menu">
                        {/* <div className="container"> */}
                            <li className="menu__item">
                                <Link to="/">Home</Link>
                            </li>
                            <li className="menu__item">
                                <Link to="/about">About</Link>
                            </li>
                            <li className="menu__item">
                                <Link to="/authorization">Authorization</Link>
                            </li>
                        {/* </div> */}
                    </ul>
                    <Route exact path="/" component={Home}/>
                    <Route path="/about" component={About}/>
                    <Route path="/authorization" component={Authorization}/>
            </BrowserRouter>
        )
    }
}

export default Nav