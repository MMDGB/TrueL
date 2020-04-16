import React, { Component } from "react";
import FormLabel from "@material-ui/core/FormLabel";
import FormGroup from "@material-ui/core/FormGroup";
import FormHelperText from "@material-ui/core/FormHelperText";
import Checkbox from "@material-ui/core/Checkbox";
import FormControl from "@material-ui/core/FormControl";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import * as repositoryActions from '../../store/actions/repositoryActions'
import { connect } from 'react-redux'

class CheckBoxSelection extends Component {
  render() {
    return (
      <div>
        <FormControl component="fieldset" className={"formControl"}>
          <FormLabel component="legend">Tickets Control Checkboxes</FormLabel>
          <FormGroup>
            <FormControlLabel
              control={
                <Checkbox
                  checked={this.props.data.excelReducer.isPolarion}
                  onChange={(e) => { this.props.setIsPolarion(e.target.checked) }}
                  value="isPolarion"
                />
              }
              label="Polarion Tickets"
            />
            <FormControlLabel
              control={
                <Checkbox
                  checked={this.props.data.excelReducer.showNames}
                  onChange={(e) => {
                    this.props.setShowNames(e.target.checked);
                    this.props.setExcelData([]);
                  }}
                  value="showUserName"
                />
              }
              label="Show Names"
            />
          </FormGroup>
          <FormHelperText>Be careful</FormHelperText>
        </FormControl>
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
    setIsPolarion: (value) => dispatch(repositoryActions.setIsPolarion(value)),
    setShowNames: (value) => dispatch(repositoryActions.setShowNames(value)),
    setExcelData: (value) => dispatch(repositoryActions.setExcelData(value)),
  }
}
export default connect(mapStateToProps, mapDispatchToProps)(CheckBoxSelection);
