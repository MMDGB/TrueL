import React, {Component} from 'react';
import { Route, Redirect } from 'react-router-dom';

class LogoutProtectedRoute extends Component {
    render() {

      const { component: Component, ...props } = this.props
  
      return (
        <Route 
          {...props} 
          render={props => (
            localStorage.getItem("currentUserName") != "" ?
            <Redirect to='/main-page' />:
            <Component {...props} /> 
          )} 
        />
      )
    }
  }
 export default LogoutProtectedRoute;
