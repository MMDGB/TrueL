import * as actionTypes from './actionTypes';

const setName = (data) => { return { type: actionTypes.CHANGE_USERNAME, data: data } }
const setPass = (data) => { return { type: actionTypes.CHANGE_PASSWORD, data: data } }
const isLogged = (data) => { return { type: actionTypes.CHANGE_ADMIN_STATUS, data: data } }
const isAdmin = (data) => { return { type: actionTypes.CHANGE_LOGGED_STATUS, data: data } }

export const setUsername = (value) => {
    return (dispatch) => {
        dispatch(setName(value))
    }
}

export const setPassword = (value) => {
    return (dispatch) => {
        dispatch(setPass(value))
    }
}

export const setLogged = (value) => {
    return (dispatch) => {
        dispatch(isLogged(value))
    }
}

export const setAdmin = (value) => {
    return (dispatch) => {
        dispatch(isAdmin(value))
    }
}

const setStart = (data) => { return { type: actionTypes.EXCEL_START_DATE, data: data } }
const setEnd = (data) => { return { type: actionTypes.EXCEL_END_DATE, data: data } }
const isPolarion = (data) => { return { type: actionTypes.EXCEL_IS_POLARION, data: data } }
const showNames = (data) => { return { type: actionTypes.EXCEL_SHOW_NAMES, data: data } }
const issueList = (data) => { return { type: actionTypes.EXCEL_ISSUE_LIST, data: data } }
const issueData = (data) => { return { type: actionTypes.EXCEL_DATA, data: data } }
const firstLoad = (data) => { return { type: actionTypes.FIRST_LOAD, data: data } }



export const setStartDate = (value) => {
    return (dispatch) => {
        dispatch(setStart(value))
    }
}

export const setEndDate = (value) => {
    return (dispatch) => {
        dispatch(setEnd(value))
    }
}

export const setIsPolarion = (value) => {
    return (dispatch) => {
        dispatch(isPolarion(value))
    }
}

export const setShowNames = (value) => {
    return (dispatch) => {
        dispatch(showNames(value))
    }
}

export const setIssueList = (value) => {
    return (dispatch) => {
        dispatch(issueList(value))
    }
}

export const setExcelData = (value) =>
{
    return (dispatch) => {
        dispatch(issueData(value))
    }
}

export const setFirstLoaded = (value) =>
{
    return (dispatch) => {
        dispatch(firstLoad(value))
    }
}