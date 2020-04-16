import React, { useState } from "react";
import { Button, FormGroup, FormControl, ControlLabel } from "react-bootstrap";
import "./Login.css";
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import IconButton from '@material-ui/core/IconButton';
import { Link } from 'react-router-dom';

export default function Login(props) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [rePassword, setREPassword] = useState("");


  function validateForm() {
    return email.length > 0 && password.length > 0;
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
              <Button >Login</Button>
            </Link>
          </IconButton>
          <IconButton>
            <Link to="/register">
              <Button>Register</Button>
            </Link>
          </IconButton>
        </Toolbar>
      </AppBar>


      <form>
        <FormGroup controlId="email" bsSize="large">
          <ControlLabel>Email</ControlLabel>
          <FormControl
            autoFocus
            type="email"
            value={email}
            onChange={e => setEmail(e.target.value)}
          />
        </FormGroup>
        <FormGroup controlId="password" bsSize="large">
          <ControlLabel>Password</ControlLabel>
          <FormControl
            value={password}
            onChange={e => setPassword(e.target.value)}
            type="password"
          />
        </FormGroup>
        <FormGroup controlId="password" bsSize="large">
          <ControlLabel>re-enter Password</ControlLabel>
          <FormControl
            value={rePassword}
            onChange={e => setREPassword(e.target.value)}
            type="password"
          />
        </FormGroup>
        <Link to="/">
          <Button block bsSize="large" disabled={!validateForm()} type="submit">
            Register
          </Button>
        </Link>

      </form>
    </div>
  );
}