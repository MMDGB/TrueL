import React, { Component } from "react";
import SelectMultipleIssues from './SelectMultipleIssues'
import SelectSingleIssue from './SelectSingleIssue'

class IssueSelection extends Component {
    render() {
        function Render(mode) {
            if (mode == 'single') {
                return <SelectSingleIssue />
            }
            else {
                return <SelectMultipleIssues />
            }
        }

        return (
            <div >
                {Render(this.props.mode)}
            </div>
        );
    }
}
export default IssueSelection

