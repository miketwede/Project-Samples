import React, {Component} from "react";
import {AgGridReact} from "ag-grid-react";

import "./CustomerDetailGrid.css";
import {formatDate, formatCurrency} from "../utilities/Common.js";

// pull in the ag-grid styles we're interested in
// import "../../../node_modules/ag-grid/dist/styles/ag-grid.css";
// import "../../../node_modules/ag-grid/dist/styles/theme-fresh.css";

export default class CustomerDetailGrid extends Component {
    constructor(props) {
        super(props);
console.log("this.props.node.parent.data", this.props.node.parent.data);
        this.state = {
            parentRecord: this.props.node.parent.data,
            // columnDefs: this.createColumnDefs(),
            // img: `images/${this.props.node.parent.data.image}.png`
            img: "data:image/jpeg;base64, " + this.props.node.parent.data.Photo
        };
        // this.onGridReady = this.onGridReady.bind(this);
        this.onSearchTextChange = this.onSearchTextChange.bind(this);

        // override the containing div so that the child grid fills the row height
        this.props.reactContainer.style.height = "100%";
    }

    onSearchTextChange(newData) {
        this.gridApi.setQuickFilter(newData);
    }

    secondCellFormatter(params) {
        return params.value.toLocaleString() + 's';
    }

    onButtonClick() {
        window.alert('Sample button pressed!!');
    }

    formatYTD(amount) {
        if (!amount) {
            return null;
        }
        else {
            // return formatCurrency(amount.substring(0, amount.indexOf('-'))) + "-" + formatCurrency(amount.substring(amount.indexOf('-')+1, amount.length-1));
            return formatCurrency(amount.substring(0, amount.indexOf('-'))) + "-" + formatCurrency(amount.substring(amount.indexOf('-')+1, amount.length));
        }
    }

    render() {
        let dateFormat = "mm/dd/yyyy";
        // console.log("this.state.parentRecord.detailRecords[0].HomeOwnerFlag", this.state.parentRecord.detailRecords[0].HomeOwnerFlag);
        if (this.state.parentRecord.detailRecords[0]){

        return (
                <div className="full-width-panel">
                <div class="row">
                    <div class="col-lg-12">

                        <div class="col-lg-3">
                            <div className="full-width-detail"><img width="120px" height="130px" src={this.state.img} alt="Customer Photo" style={{border:'2px solid gold'}}/></div>
                            {/* <div className="full-width-detail"><b>Name: </b> {this.state.parentRecord.Name}</div> */}
                            <div className="full-width-detail">{this.state.parentRecord.Name}</div>
                            {/* <div className="full-width-detail"><b>Account: </b> {this.state.parentRecord.AccountNumber}</div> */}
                        </div>

                        <div class="col-lg-3">
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Birth Date: </b> {formatDate(this.state.parentRecord.detailRecords[0].BirthDate.toLocaleString(), dateFormat)}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Marital Status: </b> {this.state.parentRecord.detailRecords[0].MaritalStatus}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Total Children: </b> {this.state.parentRecord.detailRecords[0].TotalChildren}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Children At Home: </b> {this.state.parentRecord.detailRecords[0].NumberChildrenAtHome}</div>
                        </div>

                        <div class="col-lg-3">
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Gender: </b> {this.state.parentRecord.detailRecords[0].Gender}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Education: </b> {this.state.parentRecord.detailRecords[0].Education}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Occupation: </b> {this.state.parentRecord.detailRecords[0].Occupation}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Owns Home: </b> {this.state.parentRecord.detailRecords[0].HomeOwnerFlag.toString()}</div>
                        </div>

                        <div class="col-lg-3">
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Number Of Cars Owned: </b> {this.state.parentRecord.detailRecords[0].NumberCarsOwned}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Commute Distance: </b> {this.state.parentRecord.detailRecords[0].CommuteDistance}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Yearly Income: </b> { this.formatYTD(this.state.parentRecord.detailRecords[0].YearlyIncome) }</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Date Of First Purchase: </b> {formatDate(this.state.parentRecord.detailRecords[0].DateFirstPurchase.toLocaleString(), dateFormat)}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Total Purchases YTD: </b> {formatCurrency(this.state.parentRecord.detailRecords[0].TotalPurchaseYTD)}</div>
                        </div>

            {/* <AgGridReact
                    // properties
                    columnDefs={this.state.columnDefs1}
                   rowData={this.state.parentRecord.detailRecords1}
                  enableSorting
                    enableFilter
                    enableColResize

                    // events
                    onGridReady={this.onGridReady}>
                </AgGridReact> */}

                        </div>
                    </div>
                </div>
                            );
            }
else{
    return (
                <div className="full-width-panel">
                <div class="row">
                    <div class="col-lg-12">
                    <div className="full-width-detail">No detail record found.</div>

                        </div>
                    </div>
                </div>
                            );
}

    }
}