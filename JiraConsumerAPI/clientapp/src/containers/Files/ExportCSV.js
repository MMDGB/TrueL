import Button from 'react-bootstrap/Button';
import React, { Component, useState } from 'react';
import { connect } from 'react-redux'
import './ExportCsv.css';
import * as repositoryActions from '../../store/actions/repositoryActions'
import Modal from 'react-modal';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';

const axios = require('axios').default;
class ExportCSV extends Component {
    constructor(props) {
        super(props)
        this.state = {
            updated: false,
        }
    }

    render() {
        const fileType = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8'
        const getWarranty = `api/data/allSystems/${formatDate(this.props.data.excelReducer.startDate)}/${formatDate(this.props.data.excelReducer.endDate)}/defects?isPolarion=${this.props.data.excelReducer.isPolarion}&showUsers=${this.props.data.excelReducer.showNames}`
        const getJiraIssue = `api/Data/${formatDate(this.props.data.excelReducer.startDate)}/${formatDate(this.props.data.excelReducer.endDate)}/${this.props.data.excelReducer.issueList}?isPolarion=${this.props.data.excelReducer.isPolarion}&showUsers=${this.props.data.excelReducer.showNames}`
        const getMultipleIssues = `api/data/${formatDate(this.props.data.excelReducer.startDate)}/${formatDate(this.props.data.excelReducer.endDate)}/jiraIssuesIds`
        const getNewTechIssues = `api/data/newTech/${formatDate(this.props.data.excelReducer.startDate)}/${formatDate(this.props.data.excelReducer.endDate)}/defects?isPolarion=${this.props.data.excelReducer.isPolarion}&showUsers=${this.props.data.excelReducer.showNames}`
        const getNewByIssues = `api/data/newTechByIssue/${formatDate(this.props.data.excelReducer.startDate)}/${formatDate(this.props.data.excelReducer.endDate)}/defects?isPolarion=${this.props.data.excelReducer.isPolarion}&showUsers=${this.props.data.excelReducer.showNames}`
        const updateCacheURI = `api/data/updateCache`;

        const exportToCSV = (json) => {
            if (json.length != 0) {
                this.props.setExcelData(Array.from(json));

            }
        }

        function formatDate(date) {
            if (date != null) {
                var day = date.getDate();
                var month = date.getMonth() + 1;
                var year = date.getFullYear();

                if (day < 10) { day = '0' + day; }
                if (month < 10) { month = '0' + month; }
            }

            return year + '-' + month + '-' + day;
        }

        const updateCache = () => {
            axios({
                method: 'POST',
                url: updateCacheURI,
                headers: {
                    'content-type': 'application/json'
                },
            })
                .then(res => {
                    console.log(res)
                    this.setState({ updated: false })
                })
                .catch(err => {
                    console.log(err)
                })
        }

        const postData = () => {
            if (this.props.data.excelReducer.issueList.length != 0) {
                axios({
                    method: 'POST',
                    url: getMultipleIssues,
                    headers: {
                        'content-type': 'application/json'
                    },
                    data: JSON.stringify(this.props.data.excelReducer.issueList)
                })
                    .then(res => {
                        console.log(res)
                        exportToCSV(res.data)
                    })
                    .catch(err => {
                        console.log(err)
                    })
            }
        }
        const getData = () => {
            if (this.props.data.excelReducer.issueList.length != 0 || this.props.mode == 'warranty' || this.props.mode == 'newTech' || this.props.mode == 'newTechnology') {
                axios({
                    method: 'GET',
                    url: this.props.mode == 'single' ? getJiraIssue : this.props.mode == 'warranty' ? getWarranty : this.props.mode == 'newTech' ? getNewTechIssues : getNewByIssues,
                    headers: {
                        'content-type': 'application/json'
                    },
                    data: this.props.data.excelReducer.issueList
                })
                    .then(res => {
                        console.log(res)
                        exportToCSV(res.data)
                    })
                    .catch(err => {
                        console.log(err)
                    })
            }
        }

        const handleClose = () =>
        {
            this.setState({updated:false})
        }

        const handleClick = () => {
            this.props.setExcelData([]);
            this.props.setFirstLoaded(true);
            if (this.props.mode == 'multiple') {
                postData()
            }
            else {
                if (this.props.name != undefined) {
                    this.state.updated = true;
                    updateCache()
                }
                else {
                    getData()
                }
            }
        }

        return (
            <div>
                <Button className={this.props.name != undefined ? "buttomUpdate" : ""} onClick={handleClick}>
                    {this.props.name != "Update Cache" ? 'EXPORT' : "Update Cache"}
                </Button>
                <img src="pic_trulli.jpg" alt="Trulli" width="500" height="333"/>

                <Dialog
                    open={this.state.updated}
                    onClose={handleClose}
                    aria-labelledby="alert-dialog-title"
                    aria-describedby="alert-dialog-description"
                >
                    <DialogTitle id="alert-dialog-title">{"You pressed Update Cache?"}</DialogTitle>
                    <DialogContent>
                        <DialogContentText id="alert-dialog-description">
                            We are currently updating the database !!!
                            Please be patient :D

                        </DialogContentText>
                    </DialogContent>
                </Dialog>

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
        setExcelData: (value) => dispatch(repositoryActions.setExcelData(value)),
        setFirstLoaded: (value) => dispatch(repositoryActions.setFirstLoaded(value)),
    }
}
export default connect(mapStateToProps, mapDispatchToProps)(ExportCSV);
