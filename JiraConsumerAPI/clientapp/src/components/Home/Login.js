import React, { Component } from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import IconButton from '@material-ui/core/IconButton';
import { Link } from 'react-router-dom';
import { Button, FormGroup, FormControl, ControlLabel } from "react-bootstrap";
import * as repositoryActions from '../../store/actions/repositoryActions'
import { connect } from 'react-redux'
import { Redirect } from 'react-router'


class Login extends Component {
  constructor() {
    super()
    this.state = {
      credentials: null
    }
  }

  getData() {
    require('axios').default({
      method: 'GET',
      url: `https://localhost:5001/api/data/credentials`,
      headers: {
        'content-type': 'application/json'
      },
    })
      .then(res => {
        this.setState({ credentials: res })
      })
      .catch(err => {
        console.log(err)
      })
  }

  componentDidMount() {
    this.getData();
  }

  render() {

    const validateForm = (data) => {
      return data.userName != "" && data.password != ""
    }



    const handleLogin = (data) => {
      if (this.state.credentials.data.userName == data.userName && this.state.credentials.data.password == data.password) {
        localStorage.setItem("currentUserName", data.userName)
        localStorage.setItem("currentPassword", data.password)
        return <Redirect to="/main-page" />
      }
      else
      {
        alert("Invalid UserName or Password");
        return <Redirect to="/login" />
      }

    }

    return (
      <div className="Login">
        <AppBar>
          <Toolbar>
            <Typography variant="h6" className={"title"}>
              DashBoard
          </Typography>
            <IconButton aria-label="search" color="inherit">
              <Link to="/">
                <Button>Login</Button>
              </Link>
            </IconButton>
            <IconButton>
              <Link to="/register">
                <Button >Register</Button>
              </Link>
            </IconButton>
          </Toolbar>
        </AppBar>
        <form>
          <FormGroup controlId="email" bsSize="large">
            <ControlLabel>Email</ControlLabel>
            <FormControl
              autoFocus
              // type="email"
              value={this.props.data.userReducer.userName}
              onChange={e => this.props.setUsername(e.target.value)}
            />
          </FormGroup>
          <FormGroup controlId="password" bsSize="large">
            <ControlLabel>Password</ControlLabel>
            <FormControl
              value={this.props.data.userReducer.password}
              onChange={e => this.props.setPassword(e.target.value)}
              type="password"
            />
          </FormGroup>
          <Button onClick={() => { handleLogin(this.props.data.userReducer) }} block bsSize="large" disabled={!validateForm(this.props.data.userReducer)} type="submit">
            Login
          </Button>

        </form>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    data: state
  }
}

const mapDispatchToProps = (dispatch) => {
  return {
    setUsername: (value) => dispatch(repositoryActions.setUsername(value)),
    setPassword: (value) => dispatch(repositoryActions.setPassword(value)),
    setAdmin: (value) => dispatch(repositoryActions.setAdmin(value)),
    setLogged: (value) => dispatch(repositoryActions.setUsername(value)),
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(Login);