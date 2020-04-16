/* eslint-disable */
import React, { Component } from 'react';
import "react-datepicker/dist/react-datepicker.css";
import ListItem from '@material-ui/core/ListItem';
import List from '@material-ui/core/List';
import * as repositoryActions from '../../store/actions/repositoryActions'
import { connect } from 'react-redux'
import './DTable.css'
import { Table } from 'react-bootstrap';
import * as FileSaver from 'file-saver';
import * as XLSX from 'xlsx';
import Button from 'react-bootstrap/Button';
import { SemipolarLoading } from 'react-loadingg';

class DTable extends Component {
    constructor() {
        super()
        this.state = {
            nameSort: 'down',
            userSort: 'down',
            timeSort: 'down',
            filterUser: '',
            filterTime: '',
            filterName: '',
        }
    }
    render() {
        const Save = () => {
            if (this.props.data.excelReducer.excelData.length != 0) {
                let ws = XLSX.utils.json_to_sheet(Array.from(this.props.data.excelReducer.excelData));
                let wb = { Sheets: { 'data': ws }, SheetNames: ['data'] };
                let excelBuffer = XLSX.write(wb, { bookType: 'xlsx', type: 'array' });
                let data = new Blob([excelBuffer], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8' });
                FileSaver.saveAs(data, 'exportExcel' + '.xlsx');
            }
        }

        const sortUser = (data) => {
            if (data.length > 0) {
                let arr = [].concat(data)
                if (this.state.userSort == 'up') {
                    arr.sort((a, b) => {
                        return a.UserId >= b.UserId ? 1 : -1
                    })
                    this.setState({ userSort: 'down' })
                }
                else {
                    arr.sort((a, b) => {
                        return a.UserId <= b.UserId ? 1 : -1
                    })
                    this.setState({ userSort: 'up' })
                }
                this.props.setExcelData(arr);
            }
        }

        const sortTime = (data) => {
            if (data.length > 0) {
                let arr = [].concat(data)
                if (this.state.timeSort == 'up') {
                    arr.sort((a, b) => {
                        return a.TimeSpent >= b.TimeSpent ? 1 : -1
                    })
                    this.setState({ timeSort: 'down' })
                }
                else {
                    arr.sort((a, b) => {
                        return a.TimeSpent <= b.TimeSpent ? 1 : -1
                    })
                    this.setState({ timeSort: 'up' })
                }
                this.props.setExcelData(arr);
            }
        }

        const sortName = (data) => {
            if (data.length > 0) {
                let arr = [].concat(data)
                if (this.state.nameSort == 'up') {
                    arr.sort((a, b) => {
                        return a.CompleteName >= b.CompleteName ? 1 : -1
                    })
                    this.setState({ nameSort: 'down' })
                }
                else {
                    arr.sort((a, b) => {
                        return a.CompleteName <= b.CompleteName ? 1 : -1
                    })
                    this.setState({ nameSort: 'up' })
                }
                this.props.setExcelData(arr);
            }
        }

        function loadingImage(data) {
            if (data == true) {
                return <SemipolarLoading />

            }
        }
        function makeTotalIssue(data) {
            let totalCount = 0
            for (let item of data) {
                totalCount += item.TimeSpent;
            }
            return totalCount;
        }

        return (
            <div>
                <List>
                    <ListItem>
                        <Button onClick={Save} >SAVE</Button>
                    </ListItem>
                    <ListItem>
                        <Table striped bordered hover variant="dark">
                            <thead>
                                <tr>
                                    <th><Button onClick={() => { sortName(this.props.data.excelReducer.excelData) }}> Sort By Name</Button></th>
                                    <th><Button onClick={() => { sortTime(this.props.data.excelReducer.excelData) }}> Sort By Time</Button></th>
                                    <th><Button onClick={() => { sortUser(this.props.data.excelReducer.excelData) }}> Sort By User</Button></th>
                                </tr>
                                <tr>
                                    <th>
                                        <p> Filter Name: </p>
                                        <input
                                            type="text"
                                            value={this.state.filterName}
                                            onChange={e => this.setState({ filterName: e.target.value })} />

                                    </th>
                                    <th>
                                        {makeTotalIssue(Array.from(this.props.data.excelReducer.excelData)
                                            .filter(e => e.UserId.toLowerCase().includes(this.state.filterUser))
                                            .filter(g => g.CompleteName.toLowerCase().includes(this.state.filterName))
                                            .concat(
                                                Array.from(this.props.data.excelReducer.excelData)
                                                    .filter(e => e.UserId.toLowerCase().includes(this.state.filterUser))
                                                    .filter(g => g.CompleteName.toLowerCase().includes(this.state.filterName.includes("_") ? this.state.filterName.replace("_", "") : "----------"))
                                            ))
                                        }
                                    </th>
                                    <th>
                                        <p> Filter User: </p>
                                        <input
                                            type="text"
                                            value={this.state.filterUser}
                                            onChange={e => this.setState({ filterUser: e.target.value })} />
                                    </th>
                                </tr>
                                <tr>
                                    <th>CompleteName</th>

                                    <th>TimeSpent</th>
                                    <th>UserID</th>

                                </tr>
                            </thead>
                            <tbody>
                                {Array.from(this.props.data.excelReducer.excelData)
                                    .filter(e => e.UserId.toLowerCase().includes(this.state.filterUser))
                                    .filter(g => g.CompleteName.toLowerCase().includes(this.state.filterName))
                                    .concat(
                                        Array.from(this.props.data.excelReducer.excelData)
                                            .filter(e => e.UserId.toLowerCase().includes(this.state.filterUser))
                                            .filter(g => g.CompleteName.toLowerCase().includes(this.state.filterName.includes("_") ? this.state.filterName.replace("_", "") : "----------"))
                                    )
                                    .map(function (item, key) {
                                        return (
                                            <tr key={key}>
                                                <td>{item.CompleteName}</td>
                                                <td>{item.TimeSpent}</td>
                                                <td>{item.UserId}</td>

                                            </tr>
                                        );
                                    })}
                            </tbody>
                        </Table>
                    </ListItem>
                </List>
                <List>
                    {loadingImage(this.props.data.excelReducer.isFirstLoaded)}
                </List>
            </div>
        );
    }
}



const mapStateToPropsExcel = (state) => {
    return {
        data: state
    }
}

const mapDispatchToPropsExcel = (dispatch) => {
    return {
        setStartDate: (value) => dispatch(repositoryActions.setStartDate(value)),
        setEndDate: (value) => dispatch(repositoryActions.setEndDate(value)),
        setIsPolarion: (value) => dispatch(repositoryActions.setIsPolarion(value)),
        setShowNames: (value) => dispatch(repositoryActions.setShowNames(value)),
        setIssueList: (value) => dispatch(repositoryActions.setIssueList(value)),
        setExcelData: (value) => dispatch(repositoryActions.setExcelData(value)),
    }
}

export default connect(mapStateToPropsExcel, mapDispatchToPropsExcel)(DTable);

