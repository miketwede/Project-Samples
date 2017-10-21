import React, {Component} from "react";
import {AgGridReact} from "ag-grid-react";
import {AgGrid} from "ag-grid";
import SalesTerritoryDetailGrid from "./SalesTerritoryDetailGrid.jsx";
import * as common from "../utilities/Common.js";

// pull in the ag-grid styles we're interested in
// import "../../../node_modules/ag-grid/dist/styles/ag-grid.css";
// import "../../../node_modules/ag-grid/dist/styles/theme-fresh.css";

export default class SalesTerritoryMasterGrid extends Component {



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
                headerName: 'Group', field: 'Group', width: 100, filter: "text",
                // left column is going to act as group column, with the expand / contract controls
                cellRenderer: 'group',
                // we don't want the child count - it would be one each time anyway as each parent
                // not has exactly one child node
                cellRendererParams: {suppressCount: true}
            },
            {headerName: "Country", field: "Country", width: 100},
            {headerName: "Region", field: "Region", width: 100},
            {headerName: "SalesLastYear", field: "SalesLastYear", width: 100},
            {headerName: "SalesYTD", field: "SalesYTD", width: 100},
            {headerName: "CostLastYear", field: "CostLastYear", width: 100},
            {headerName: "CostYTD", field: "CostYTD", width: 100}
        ];
    }
    
    createRowData() {
        let rowData = [];
        let rows = this.props.rows;
        
        for (let i = 0; i < rows.length; i++) {
            let Group = rows[i].group;
            let Country = rows[i].country;
            let Region = rows[i].region;
            let SalesLastYear = rows[i].salesLastYear;
            let SalesYTD = rows[i].salesYTD;
            let CostLastYear = rows[i].costLastYear;
            let CostYTD = rows[i].costYTD;
            
            let detailRecords = [];
            for (let j = 0; j < rows[i].salesPersons.length; j++) {
                
                let detailRecord = {
                    ID: rows[i].salesPersons[j].salesPersonID,
                    Person: { 
                        Name: common.formatName(rows[i].salesPersons[j].person),
                        Address: common.formatAddress(rows[i].salesPersons[j].person),
                        EmailAddress: rows[i].salesPersons[j].person.emailAddress, 
                        PhoneNumber: rows[i].salesPersons[j].person.phoneNumber, 
                        Photo: rows[i].salesPersons[j].person.photo 
                    },
                    SalesQuota: rows[i].salesPersons[j].salesQuota,
                    Bonus: rows[i].salesPersons[j].bonus,
                    CommissionPct: rows[i].salesPersons[j].commissionPct,
                    SalesYTD: rows[i].salesPersons[j].salesYTD,
                    SalesLastYear: rows[i].salesPersons[j].salesLastYear,
                    
                };
                detailRecords.push(detailRecord);
        }

            let masterRecord = {
                Group: Group,
                Country: Country,
                Region: Region,
                SalesLastYear: SalesLastYear,
                SalesYTD: SalesYTD,
                CostLastYear: CostLastYear,
                CostYTD: CostYTD,
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
                    fullWidthCellRendererFramework={SalesTerritoryDetailGrid}

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
