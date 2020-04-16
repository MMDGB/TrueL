import * as actionTypes from '../actions/actionTypes';
import { combineReducers } from 'redux'

const user = {
    userName: "",
    password: "",
    isAdmin: false,
    isLogged: false
}
const changeUsername = (state, action) => { return { ...state, userName: action.data } }
const changePassword = (state, action) => { return { ...state, password: action.data } }
const changeAdminStatus = (state, action) => { return { ...state, isAdmin: action.data } }
const changeLoggedStatus = (state, action) => { return { ...state, isLogged: action.data } }
const userReducer = (state = user, action) => {
    switch (action.type) {
        case actionTypes.CHANGE_USERNAME:
            return changeUsername(state, action);
        case actionTypes.CHANGE_PASSWORD:
            return changePassword(state, action);
        case actionTypes.CHANGE_ADMIN_STATUS:
            return changeAdminStatus(state, action);
        case actionTypes.CHANGE_LOGGED_STATUS:
            return changeLoggedStatus(state, action);
        default:
            return state;
    }
}
localStorage.setItem("ussersList",
    JSON.stringify([
        {
            userName: "user",
            password: "user",
        },
        {
            userName: "admin",
            password: "admin",
        }
    ])
)

localStorage.setItem("curentUserName", "");
localStorage.setItem("currentPassword", "");
localStorage.setItem("currentIsLogged", false);
localStorage.setItem("currentPage", "");
localStorage.setItem("navbarStatus", "Open")

const excel = {
    startDate: new Date(new Date().getFullYear(), new Date().getMonth(), 1),
    endDate: new Date(new Date().getFullYear(), new Date().getMonth() + 1, 0),
    isPolarion: false,
    showNames: false,
    issueList: [],
    excelData: [],
    isFirstLoaded: false,
    currentPage: ""
}

const changeStartDate = (state, action) => { return { ...state, startDate: action.data } }
const changeEndDate = (state, action) => { return { ...state, endDate: action.data } }
const changeIsPolarion = (state, action) => { return { ...state, isPolarion: action.data } }
const changeShowNames = (state, action) => { return { ...state, showNames: action.data } }
const changeIssueList = (state, action) => { return { ...state, issueList: action.data } }
const changeExcelData = (state, action) => { return { ...state, excelData: action.data } }
const changeFirstLoad = (state, action) => { return { ...state, isFirstLoaded: action.data } }
const excelReducer = (state = excel, action) => {
    switch (action.type) {
        case actionTypes.EXCEL_START_DATE:
            return changeStartDate(state, action);
        case actionTypes.EXCEL_END_DATE:
            return changeEndDate(state, action);
        case actionTypes.EXCEL_IS_POLARION:
            return changeIsPolarion(state, action);
        case actionTypes.EXCEL_SHOW_NAMES:
            return changeShowNames(state, action);
        case actionTypes.EXCEL_ISSUE_LIST:
            return changeIssueList(state, action);
        case actionTypes.EXCEL_DATA:
            return changeExcelData(state, action);
        case actionTypes.FIRST_LOAD:
            return changeFirstLoad(state, action);

        default:
            return state;
    }
}

export default combineReducers({ userReducer, excelReducer });