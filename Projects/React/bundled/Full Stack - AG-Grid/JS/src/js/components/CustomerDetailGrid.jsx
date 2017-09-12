import React, {Component} from "react";
import {AgGridReact} from "ag-grid-react";

import "./CustomerDetailGrid.css";

// pull in the ag-grid styles we're interested in
// import "../../../node_modules/ag-grid/dist/styles/ag-grid.css";
// import "../../../node_modules/ag-grid/dist/styles/theme-fresh.css";

export default class CustomerDetailGrid extends Component {
    constructor(props) {
        super(props);

        this.state = {
            parentRecord: this.props.node.parent.data,
            columnDefs: this.createColumnDefs(),
            img: `images/${this.props.node.parent.data.image}.png`
        };
        console.log("this.parentRecord", this.props);
        this.onGridReady = this.onGridReady.bind(this);
        this.onSearchTextChange = this.onSearchTextChange.bind(this);

        // override the containing div so that the child grid fills the row height
        this.props.reactContainer.style.height = "100%";
    }

    onGridReady(params) {
        this.gridApi = params.api;
        this.columnApi = params.columnApi;

        this.gridApi.setRowData(this.state.parentRecord.detailRecords);
        setTimeout(() => {
            this.gridApi.sizeColumnsToFit();
        })
    }

    onSearchTextChange(newData) {
        this.gridApi.setQuickFilter(newData);
    }

    createColumnDefs() {
        return [
            {headerName: 'BirthDate', field: 'BirthDate', cellClass: 'call-record-cell'},
            {headerName: 'Gender', field: 'Gender', cellClass: 'call-record-cell'},
            {headerName: 'Education', field: 'Education', cellClass: 'call-record-cell'},
            {headerName: 'Occupation', field: 'Occupation', cellClass: 'call-record-cell'},
            {headerName: 'MaritalStatus', field: 'MaritalStatus', cellClass: 'call-record-cell'},
            {headerName: 'TotalChildren', field: 'TotalChildren', cellClass: 'call-record-cell'},
            {headerName: 'NumberChildrenAtHome', field: 'NumberChildrenAtHome', cellClass: 'call-record-cell'},
            {headerName: 'HomeOwnerFlag', field: 'HomeOwnerFlag', cellClass: 'call-record-cell'},
            {headerName: 'CommuteDistance', field: 'CommuteDistance', cellClass: 'call-record-cell'},
            {headerName: 'DateFirstPurchase', field: 'DateFirstPurchase', cellClass: 'call-record-cell'},
            {headerName: 'NumberCarsOwned', field: 'NumberCarsOwned', cellClass: 'call-record-cell'},
            {headerName: 'TotalPurchaseYTD', field: 'TotalPurchaseYTD', cellClass: 'call-record-cell'},
            {headerName: 'YearlyIncome', field: 'YearlyIncome', cellClass: 'call-record-cell'}];

            
    }

    secondCellFormatter(params) {
        return params.value.toLocaleString() + 's';
    }

    onButtonClick() {
        window.alert('Sample button pressed!!');
    }

    render() {
        return (
            <div className="full-width-panel">
                <div className="full-width-details">
                    <div className="full-width-detail"><img width="120px" src={this.state.img}/></div>
                    <div className="full-width-detail"><b>Name: </b> {this.state.parentRecord.Name}</div>
                    {/* <div className="full-width-detail"><b>Account: </b> {this.state.parentRecord.detailRecords[0].BirthDate}</div> */}
                </div>
                <AgGridReact
                    // properties
                    columnDefs={this.state.columnDefs}
                   rowData={this.state.parentRecord.detailRecords}
                  enableSorting
                    enableFilter
                    enableColResize

                    // events
                    onGridReady={this.onGridReady}>
                </AgGridReact>
            </div>
        );
    }
}