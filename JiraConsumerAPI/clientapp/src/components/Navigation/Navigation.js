import React from 'react';
import { Button } from "react-bootstrap";
import clsx from 'clsx';
import { makeStyles, useTheme } from '@material-ui/core/styles';
import Drawer from '@material-ui/core/Drawer';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import List from '@material-ui/core/List';
import CssBaseline from '@material-ui/core/CssBaseline';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import IconButton from '@material-ui/core/IconButton';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import InboxIcon from '@material-ui/icons/MoveToInbox';
import BusinessIcon from '@material-ui/icons/Business';
import BusinessCenterIcon from '@material-ui/icons/BusinessCenter';
import DirectionsBusIcon from '@material-ui/icons/DirectionsBus';
import MailIcon from '@material-ui/icons/Mail';
import { Link } from 'react-router-dom';
import ExportCSV from '../../containers/Files/ExportCSV'


const drawerWidth = 200;

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
    flexFlow: "column",
  },
  appBar: {
    zIndex: theme.zIndex.drawer + 1,
    transition: theme.transitions.create(['width', 'margin'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
  },
  appBarShift: {
    marginLeft: drawerWidth,
    width: `calc(100% - ${drawerWidth}px)`,
    transition: theme.transitions.create(['width', 'margin'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  },
  menuButton: {
    marginRight: 36,
  },
  hide: {
    display: 'none',
  },
  drawer: {
    width: drawerWidth,
    flexShrink: 0,
    whiteSpace: 'nowrap',
  },
  drawerOpen: {
    width: drawerWidth,
    transition: theme.transitions.create('width', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  },
  drawerClose: {
    transition: theme.transitions.create('width', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
    overflowX: 'hidden',
    width: theme.spacing(7) + 1,
    [theme.breakpoints.up('sm')]: {
      width: theme.spacing(9) + 1,
    },
  },
  toolbar: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'flex-end',
    padding: theme.spacing(0, 1),
    ...theme.mixins.toolbar,
  },
  content: {
    flexGrow: 1,
    padding: theme.spacing(3),
  },
  bottomNavigation:
  {
    paddingTop: '400px',
  }
}));

export default function Navigation() {

  const [open, setOpen] = React.useState(true)

  const classes = useStyles();
  const theme = useTheme();
  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const handleDrawerClose = () => {
    setOpen(false);
  };

  const logOut = () => {
    localStorage.setItem("currentUserName", "")
    localStorage.setItem("currentPassword", "")
  }

  return (
    <div className={classes.root}>
      <CssBaseline />
      <AppBar
        position="fixed"
        className={clsx(classes.appBar, {
          [classes.appBarShift]: open,
        })}
      >
        <Toolbar>
          <IconButton
            color="inherit"
            size="small"
            aria-label="open drawer"
            onClick={handleDrawerOpen}
            edge="start"
            className={clsx(classes.menuButton, {
              [classes.hide]: open,
            })}
          >
            <img src="https://img.icons8.com/carbon-copy/30/000000/menu.png" />
          </IconButton>
          <Typography variant="h6" noWrap className={"title"}>
            {localStorage.getItem("currentPage")}
          </Typography>
          <Link to="/">
            <Button onClick={logOut}>Log-out</Button>
          </Link>
        </Toolbar>
      </AppBar>

      <Drawer
        variant="permanent"
        className={clsx(classes.drawer,
          {
            [classes.drawerOpen]: open,
            [classes.drawerClose]: !open,
          })}
        classes=
        {{
          paper: clsx(
            {
              [classes.drawerOpen]: open,
              [classes.drawerClose]: !open,
            }),
        }}
      >
        <div className={classes.toolbar}>
          <IconButton onClick={handleDrawerClose}>
            {theme.direction === 'rtl' ? <ChevronRightIcon /> : <ChevronLeftIcon />}
          </IconButton>
        </div>
        <Divider />
        <List>
          {['Multiple issues'].map((text, index) => (
            <ListItem href="/multiple-issue" component="a" selected={localStorage.getItem("currentPage") == "Get-Multiple-Issues"} button key={text}>
              <ListItemIcon > <InboxIcon /></ListItemIcon>
              <ListItemText primary={text} />
            </ListItem>
          ))},
           {['Single Issue'].map((text, index) => (
            <ListItem href="/single-issue" component="a" selected={localStorage.getItem("currentPage") == "Single-Issue"} button key={text}>
              <ListItemIcon ><BusinessIcon/></ListItemIcon>
              <ListItemText primary={text} />
            </ListItem>
          ))},
           {['Warranty'].map((text, index) => (
            <ListItem href="/warranty" component="a" selected={localStorage.getItem("currentPage") == "Warranty"} button key={text}>
              <ListItemIcon >{<BusinessCenterIcon/>}</ListItemIcon>
              <ListItemText primary={text} />
            </ListItem>
          ))},
          {['New Technologyes'].map((text, index) => (
            <ListItem href="/newTech" component="a" selected={localStorage.getItem("currentPage") == "New-Tech-General"} button key={text}>

             <ListItemIcon >{<MailIcon />}</ListItemIcon>
            <ListItemText primary={text} />
           </ListItem>
         ))},
         {['New Technologyes Issues'].map((text, index) => (
              <ListItem href="/newTechByIssue" component="a" selected={localStorage.getItem("currentPage") == "New-Tech-By-Issue"} button key={text}>
                <ListItemIcon >{<DirectionsBusIcon />}</ListItemIcon>
                <ListItemText primary={text} />
              </ListItem>
            ))},
        {['Feature 6'].map((text, index) => (
              <ListItem href="/feature-not-implemented" component="a" button key={text}>
                <ListItemIcon >{index % 2 === 0 ? <InboxIcon /> : <MailIcon />}</ListItemIcon>
                <ListItemText primary={text} />
              </ListItem>
            ))},
       {['Feature 7'].map((text, index) => (
              <ListItem href="/feature-not-implemented" component="a" button key={text}>
                <ListItemIcon >{index % 2 === 0 ? <InboxIcon /> : <MailIcon />}</ListItemIcon>
                <ListItemText primary={text} />
              </ListItem>
            ))}
        </List>
        <List className={classes.bottomNavigation}>
          <ExportCSV  name = "Update Cache"/>
        </List>
      </Drawer>
    </div >
  );
}