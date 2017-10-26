import React, {Component} from "react";
import {AgGridReact} from "ag-grid-react";
import {AgGrid} from "ag-grid";

// C:\Dev\React\ReactTraining\Full Stack - AG-Grid\JS\node_modules\ag-grid\dist

import CustomerDetailGrid from "./CustomerDetailGrid.jsx";
//import "../utilities/Common.js";
import * as common from "../utilities/Common.js";

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
            let Name = common.formatName(rows[i].person); 
            let Phone = rows[i].person.phoneNumber;
            let Email = rows[i].person.emailAddress;
            let AccountNumber = rows[i].accountNumber;
            let Address = common.formatAddress(rows[i].person);
            let Photo = rows[i].person.photo;
            let IndividualSurvey = rows[i].demographics;
            
            let detailRecords = [];
            if (IndividualSurvey){
                let detailRecord = {
                TotalPurchaseYTD: IndividualSurvey.totalPurchaseYTD,
                DateFirstPurchase: IndividualSurvey.dateFirstPurchase,
                BirthDate: IndividualSurvey.birthDate,
                MaritalStatus: IndividualSurvey.maritalStatus,
                YearlyIncome: IndividualSurvey.yearlyIncome,
                Gender: IndividualSurvey.gender,
                TotalChildren: IndividualSurvey.totalChildren,
                NumberChildrenAtHome: IndividualSurvey.numberChildrenAtHome,
                Education: IndividualSurvey.education,
                Occupation: IndividualSurvey.occupation,
                HomeOwnerFlag: IndividualSurvey.homeOwnerFlag,
                NumberCarsOwned: IndividualSurvey.numberCarsOwned,
                CommuteDistance: IndividualSurvey.commuteDistance
                };
                detailRecords.push(detailRecord);
            }


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
                <h1>Customers</h1>
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
