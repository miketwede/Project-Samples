import React, {Component} from "react";
import {AgGridReact} from "ag-grid-react";
import {AgGrid} from "ag-grid";

// C:\Dev\React\ReactTraining\Full Stack - AG-Grid\JS\node_modules\ag-grid\dist

import CustomerDetailGrid from "./CustomerDetailGrid.jsx";

//import * as utility from "../utilities/Common.js";


// pull in the ag-grid styles we're interested in
// import "../../../node_modules/ag-grid/dist/styles/ag-grid.css";
// import "../../../node_modules/ag-grid/dist/styles/theme-fresh.css";

export default class CustomerMasterGrid extends Component {



    constructor(props) {
        super(props);

        this.state = {
            columnDefs: this.createColumnDefs(),
            //rowData: this.createRowData().bind(this),
            rowData: this.createRowData(),
            dateFormat: "mm/dd/yyyy"
        };
      //  this.createRowData=this.createRowData.bind(this.state);
    }


    onGridReady(params) {
        this.gridApi = params.api;
        this.columnApi = params.columnApi;

        this.gridApi.sizeColumnsToFit();
    }

    createColumnDefs() {
        return [
            {
                headerName: 'Name', field: 'Name', width: 100, filter: "text",
                // left column is going to act as group column, with the expand / contract controls
                cellRenderer: 'group',
                // we don't want the child count - it would be one each time anyway as each parent
                // not has exactly one child node
                cellRendererParams: {suppressCount: true}
            },
            // {headerName: "Name", field: "Name", width: 100},
            {headerName: "Phone", field: "Phone", width: 100},
            {headerName: "Email", field: "Email", width: 100},
            {headerName: "AccountNumber", field: "AccountNumber", width: 75, filter: "text"},
            {headerName: "Address", field: "Address", width: 300}
            // {headerName: "IndividualSurvey", field: "detailRecord", width: 900}
        ];
    }

    createRowData() {
        let rowData = [];
        let rows = this.props.rows;
        
        for (let i = 0; i < rows.length; i++) {
            let Name = rows[i].Title + " " + rows[i].FirstName + " " + rows[i].MiddleInitial + " " + rows[i].LastName + " " + rows[i].Suffix;
            let Phone = rows[i].PhoneNumber;
            let Email = rows[i].EmailAddress;
            let AccountNumber = rows[i].AccountNumber;
            let Address = rows[i].Address1 + " " + rows[i].Address2 + " " + rows[i].City + ", " + rows[i].State + "   " + rows[i].Zip + "   " + rows[i].Country;
            let Photo = rows[i].Photo;
            let IndividualSurvey = rows[i].Demographics;
            
            let detailRecords = [];
            let detailRecord = {
                TotalPurchaseYTD: IndividualSurvey.TotalPurchaseYTD,
                DateFirstPurchase: IndividualSurvey.DateFirstPurchase,
                BirthDate: IndividualSurvey.BirthDate,
                MaritalStatus: IndividualSurvey.MaritalStatus,
                YearlyIncome: IndividualSurvey.YearlyIncome,
                Gender: IndividualSurvey.Gender,
                TotalChildren: IndividualSurvey.TotalChildren,
                NumberChildrenAtHome: IndividualSurvey.NumberChildrenAtHome,
                Education: IndividualSurvey.Education,
                Occupation: IndividualSurvey.Occupation,
                HomeOwnerFlag: IndividualSurvey.HomeOwnerFlag,
                NumberCarsOwned: IndividualSurvey.NumberCarsOwned,
                CommuteDistance: IndividualSurvey.CommuteDistance
            };
            detailRecords.push(detailRecord);

            let masterRecord = {
                Name: Name,
                Phone: Phone,
                Email: Email,
                AccountNumber: AccountNumber,
                Address: Address,
                Photo: Photo,
                detailRecords: detailRecords
            };

            rowData.push(masterRecord);
        }

        return rowData;
    }

    minuteCellFormatter(params) {
        return params.value.toLocaleString() + 'm';
    };

    isFullWidthCell(rowNode) {
        return rowNode.level === 1;
    }

    getRowHeight(params) {
        let rowIsDetailRow = params.node.level === 1;
        // return 100 when detail row, otherwise return 25
        return rowIsDetailRow ? 200 : 25;
    }

    getNodeChildDetails(masterRecord) {
        
        if (masterRecord.detailRecords) {
            return {
                group: true,
                // the key is used by the default group cellRenderer
                key: masterRecord.Name,
                // provide ag-Grid with the children of this group
                children: [masterRecord.detailRecords]
                // for demo, expand the third row by default
               // expanded: record.account === 177002
            };
        } else {
            return null;
        }
    }

    render() {
        let containerStyle = {
            height: 800,
            width: 1500
        };

        return (
            <div style={containerStyle} className="ag-fresh">
                <h1>Master-Detail Example</h1>
                <AgGridReact
                    // properties
                    columnDefs={this.state.columnDefs}
                    rowData={this.state.rowData}

                    isFullWidthCell={this.isFullWidthCell}
                    getRowHeight={this.getRowHeight}
                    getNodeChildDetails={this.getNodeChildDetails}
                    fullWidthCellRendererFramework={CustomerDetailGrid}

                    enableSorting
                    enableFilter
                    enableColResize

                    // events
                    onGridReady={this.onGridReady}>
                </AgGridReact>
                <br/><br/>
            </div>
        )
    }

};
