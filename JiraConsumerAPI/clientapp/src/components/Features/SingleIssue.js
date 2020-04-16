/* eslint-disable */
import React, { Component } from 'react';
import './SingleIssue.css';
import "react-datepicker/dist/react-datepicker.css";
import Navigation from '../Navigation/Navigation';
import Box from '@material-ui/core/Box';
import ListItem from '@material-ui/core/ListItem';
import List from '@material-ui/core/List';
import DatePicker from 'react-datepicker';
import IssueSelection from '../IssueSelection/IssueSelection'
import ExportCSV from '../../containers/Files/ExportCSV'
import CheckBoxSelection from '../IssueSelection/CheckBoxSelection'
import * as repositoryActions from '../../store/actions/repositoryActions'
import { connect } from 'react-redux'
import './SingleIssue.css'
import DTable from '../Layout/DTable';
import TTable from '../Layout/TTable';


class SingleIssue extends Component {
    constructor()
    {
        super();
        this.state = {
            navbar: localStorage.getItem("navbarStatus")
        }
    }
    componentWillMount() {
        localStorage.setItem("currentPage","Single-Issue")
      }
    render() {
        function showTable(showNames) {
            if (showNames == true) {
                return <DTable />
            }
            else {
                return <TTable />
            }
        }
        return (
            <div className={this.state.navbar == "Open" ? "paperAnchorTop" : "paperAnchorTopClosed"}>
                <Navigation place={"single"} />
                
                <List display="inline-block">
                    <ListItem>
                        <Box display="flex" color="text.primary" clone>
                            <List>
                                <ListItem>
                                    <p className={"fontSizeStart"}>Start Date: </p>
                                    <DatePicker
                                        onChange={(date) => { this.props.setStartDate(date) }}
                                        selected={this.props.data.excelReducer.startDate}
                                        inline
                                    />
                                </ListItem>
                            </List>
                        </Box>
                        <Box display="flex" color="text.primary" clone>
                            <List>
                                <ListItem>
                                    <p className={"fontSizeEnd"}>End Date: </p>
                                    <DatePicker
                                        onChange={(date) => { this.props.setEndDate(date) }}
                                        selected={this.props.data.excelReducer.endDate}
                                        inline
                                    />
                                </ListItem>
                            </List>
                        </Box>
                        <Box display="flex" color="text.primary" clone>
                            <List>
                                <ListItem >
                                    <IssueSelection mode={'single'} />
                                </ListItem>
                                <ListItem>
                                    <ExportCSV mode={'single'} />
                                </ListItem>
                            </List>
                        </Box>
                        <Box display="flex" color="text.primary" clone>
                            <List>
                                <ListItem>
                                    <CheckBoxSelection />
                                </ListItem>
                            </List>
                        </Box>
                    </ListItem>
                    {showTable(this.props.data.excelReducer.showNames)}
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

export default connect(mapStateToPropsExcel, mapDispatchToPropsExcel)(SingleIssue);

