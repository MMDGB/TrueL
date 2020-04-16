import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './containers/App';
import * as serviceWorker from './serviceWorker';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';


import repositoryReducer from './store/reducers/repositoryReducer';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';

var store = createStore(repositoryReducer, applyMiddleware(thunk));

ReactDOM.render(

    <Provider store={store}>
        <App />
    </Provider>

    , document.getElementById('root')
);
serviceWorker.unregister();
