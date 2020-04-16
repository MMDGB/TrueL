import React, {Component} from 'react';
import {Route, Redirect } from 'react-router-dom';

class LoginProtectedRoute extends Component {
    render() {
      const { component: Component, ...props } = this.props
  
      return (
        <Route 
          {...props} 
          render={props => (
            this.props.authenticated ?
              <Component {...props} /> :
              <Redirect to='/' />
          )} 
        />
      )
    }
  }
 export default LoginProtectedRoute;
