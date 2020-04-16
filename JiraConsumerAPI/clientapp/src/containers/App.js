import React, { Component } from 'react';
import './App.css';
import { BrowserRouter, Switch, Route, Redirect } from 'react-router-dom';
import NotFound from '../components/ErrorPages/NotFound';
import Register from '../components/Home/Register'
import LoginProtectedRoute from '../components/Routes/LoginProtectedRoute'
import LogoutProtectedRoute from '../components/Routes/LogoutProtectedRoute'
import NotImplemented from '../components/ErrorPages/NotImplemented';
import Login from '../components/Home/Login';
import MainPage from '../components/Home/MainPage'
import GetMultipleIssues from '../components/Features/GetMultipleIssues'
import SingleIssue from '../components/Features/SingleIssue'
import Warranty from '../components/Features/Warranty'
import NewTechnologies from '../components/Features/NewTechnologies'
import NewTechByIssue from '../components/Features/NewTechByIssue'

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Switch>
          <LogoutProtectedRoute path="//" component={Login} />
          <LoginProtectedRoute authenticated={true} path="/main-page" component={MainPage} />
          <Route path="/register" component={Register} />
          <Route path="/multiple-issue" component={GetMultipleIssues} />
          <Route path="/warranty" component={Warranty} />
          <Route path="/newTech" component={NewTechnologies} />
          <Route path="/single-issue" component={SingleIssue} />
          <Route path="/newTechByIssue" component={NewTechByIssue} />
          <Route path="/feature-not-implemented" component={NotImplemented} />
          <Route path="*" component={NotFound} />
        </Switch>
      </BrowserRouter>
    );
  }
}

export default App;
