import React, {Component} from "react";
import {AgGridReact} from "ag-grid-react";
import {AgGrid} from "ag-grid";
import SalesTerritoryDetailGrid from "./SalesTerritoryDetailGrid.jsx";
import * as common from "../utilities/Common.js";
import Modal from 'react-modal';
import { saveSalesTerritory, getSalesTerritories} from "../services/DataService";

// pull in the ag-grid styles we're interested in
// import "../../../node_modules/ag-grid/dist/styles/ag-grid.css";
// import "../../../node_modules/ag-grid/dist/styles/theme-fresh.css";


const customStyles = {
  content : {
    top                   : '50%',
    left                  : '50%',
    right                 : 'auto',
    bottom                : 'auto',
    marginRight           : '-50%',
    transform             : 'translate(-50%, -50%)'
  }
};


export default class SalesTerritoryMasterGrid extends Component {



    constructor(props) {
        super(props);

        this.state = {
            propData: this.props.rows,
            columnDefs: null,
            rowData: null,
            dateFormat: "mm/dd/yyyy",
            modalIsOpen: false,
            SalesLastYear: 0.0,
            SalesYTD: 0.0,
            CostLastYear: 0.0,
            CostYTD: 0.0
            
        };
       // this.createRowData=this.createRowData.bind(this.state);

        // Modal functions
        this.openModal = this.openModal.bind(this);
        this.afterOpenModal = this.afterOpenModal.bind(this);
        this.closeModal = this.closeModal.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        
        // Grid functions
        this.onRowSelected = this.onRowSelected.bind(this);
        this.createColumnDefs = this.createColumnDefs.bind(this);
        this.createRowData = this.createRowData.bind(this);
    }

    componentDidMount() {
        this.setState({
            columnDefs: this.createColumnDefs(),
            rowData: this.createRowData()
        });

    }


    // *********************************************
    // Modal properties, methods and events
    // *********************************************

    openModal() {
        if (!jQuery.isEmptyObject(this.currentRecord) ){
            this.setState({modalIsOpen: true});
        }
    }

    afterOpenModal() {
    // references are now sync'd and can be accessed.
    this.subtitle.style.color = '#f00';
    }

    closeModal() {
    this.setState({modalIsOpen: false});
   // this.currentRecord = {};
    }



    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;
    
        console.log("this.currentRecord.SalesLastYear", this.currentRecord.SalesLastYear);
        console.log("value", value);
        
        this.setState({
          [name]: value
        });
      }
    

    handleSubmit(event) {
      //  alert('A name was submitted: ' + this.state.value);
      this.currentRecord.SalesLastYear = common.unFormatCurrency(this.state.SalesLastYear);
      this.currentRecord.SalesYTD = common.unFormatCurrency(this.state.SalesYTD);
      this.currentRecord.CostLastYear = common.unFormatCurrency(this.state.CostLastYear);
      this.currentRecord.CostYTD = common.unFormatCurrency(this.state.CostYTD);
      console.log("this.currentRecord", this.currentRecord);









      saveSalesTerritory(this.currentRecord)
      .then(function (response) {
        var salesTerritoryPromise = getSalesTerritories();
        var self = this;
        
        salesTerritoryPromise
        .then(function (response) {

            this.setState({propData: response});
                this.createRowData() ;

        })
       .catch(function (error) {
            console.log("error", error);
            // self.setState({
            //     ErrorsOccurred: true,
            //     ErrorMessage: error.toString()
            //     });
       });

       // api.refreshCells(response)

   })
   .catch(function (error) {
    console.log("error", error);
  //  return error;
 // throw new Error(error);
  throw error;
});
      ;

        event.preventDefault();
    }



    // *********************************************
    // Grid properties, methods and events
    // *********************************************

    currentRecord = {};

    onGridReady(params) {
        this.gridApi = params.api;
        this.columnApi = params.columnApi;

        this.gridApi.sizeColumnsToFit();
    }

    onRowSelected(params) {
        console.log("params", params.data);
        this.currentRecord = params.data;
        this.setState({SalesLastYear: params.data.SalesLastYear});
        this.setState({SalesYTD: params.data.SalesYTD});
        this.setState({CostLastYear: params.data.CostLastYear});
        this.setState({CostYTD: params.data.CostYTD});
        
    }

   
    getSimpleCellRenderer() {
        function SimpleCellRenderer() {}
    
        SimpleCellRenderer.prototype.init = function(params) {
            var tempDiv = document.createElement('div');
            if (params.node.group) {
                // tempDiv.innerHTML = '<span style="border-bottom: 1px solid grey; border-left: 1px solid grey; padding: 2px;">' + 'params.value1' + '</span>';
                tempDiv.innerHTML = '<button onClick={' + 'this.openModal' + '}>Open Modal</button>';
            } else {
                tempDiv.innerHTML = '<button type="button" onClick={this.openModal}>Click Me too!</button>';

                    // '<span><img src="https://flags.fmcdn.net/data/flags/mini/ie.png" style="width: 20px; padding-right: 4px;"/>' + 'params.value2' + '</span>';
            }
            this.eGui = tempDiv.firstChild;
        };
    
        SimpleCellRenderer.prototype.getGui = function() {
            return this.eGui;
        };
    
        return SimpleCellRenderer;
    }

    createColumnDefs() {
        return [
            {
                headerName: 'Group', field: 'Group', width: 100, filter: "text",
                // left column is going to act as group column, with the expand / contract controls
                cellRenderer: 'group',
                // we don't want the child count - it would be one each time anyway as each parent
                // not has exactly one child node
                cellRendererParams: {suppressCount: true, checkbox: true}
            },
            {headerName: "Country", field: "Country", width: 100},
            {headerName: "Region", field: "Region", width: 100},
            {headerName: "SalesLastYear", field: "SalesLastYear", width: 100},
            {headerName: "SalesYTD", field: "SalesYTD", width: 100},
            {headerName: "CostLastYear", field: "CostLastYear", width: 100},
            {headerName: "CostYTD", field: "CostYTD", width: 100},
            {headerName: "TerritoryID", field: "TerritoryID", width: 100, hide: true},
            
    // add in a cell renderer params
    // {
    //     headerName: 'Group Renderer C',
    //     showRowGroup: false,
    //     cellRenderer: 'group',
    //     field: 'Group',
    //     cellRendererParams: {
    //         suppressCount: true,
    //         checkbox: false,
    //         padding: 20,
    //         innerRenderer: this.getSimpleCellRenderer()
    //     }
    // },

        ];
    }
    
    createRowData() {
        let rowData = [];
        let rows = this.state.propData;
        
        for (let i = 0; i < rows.length; i++) {
            let Group = rows[i].group;
            let Country = rows[i].country;
            let Region = rows[i].region;
            let SalesLastYear = common.formatCurrency(rows[i].salesLastYear);
            let SalesYTD = common.formatCurrency(rows[i].salesYTD);
            let CostLastYear = common.formatCurrency(rows[i].costLastYear);
            let CostYTD = common.formatCurrency(rows[i].costYTD);
            let TerritoryID = rows[i].territoryID;
            
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
                TerritoryID: TerritoryID,
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
        let rowHeight = rowIsDetailRow ? (params.data ? (params.data.length * 250) : 100) : 25;

        return rowHeight;
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
            height: 650,
            width: 1500
        };

        return (
            <div>
            <div>
                <h1>Sales Territories</h1>
                </div>

            <div style={containerStyle} className="ag-fresh">
            <button onClick={this.openModal}>Edit</button>
            <button onClick={this.openModal}>New</button>
            <button onClick={this.openModal}>Delete</button>
            
             {/* <div  className="ag-fresh"> */}
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

                    rowSelection = 'single'
                    // events
                     onRowSelected={this.onRowSelected} 
                    // rowClicked={this.onRowSelected}
                    //cellClicked={this.onRowSelected}
                    onGridReady={this.onGridReady}>
                </AgGridReact>
                <br/><br/>
                </div>


                <Modal
                    isOpen={this.state.modalIsOpen}
                    onAfterOpen={this.afterOpenModal}
                    onRequestClose={this.closeModal}
                    style={customStyles}
                    contentLabel="Example Modal"
                    >

                    <h2 ref={subtitle => this.subtitle = subtitle}>Edit Sales Territory</h2>

                    <form onSubmit={this.handleSubmit}>


                        <label>
                        Group: {this.currentRecord.Group}
                        </label>

                        <br />

                        <label>
                        Country: {this.currentRecord.Country}
                        </label>

                        <br />

                        <label>
                        Region: {this.currentRecord.Region}
                        </label>

                        <br />

                        <label>SalesLastYear: </label>   
                        <input name="SalesLastYear" type="text" value={this.state.SalesLastYear} onChange={this.handleInputChange} />

                        <br />

                        <label>SalesYTD: </label>   
                        <input name="SalesYTD" type="text" value={this.state.SalesYTD} onChange={this.handleInputChange} />


                        <br />

                        <label>CostLastYear: </label>   
                        <input name="CostLastYear" type="text" value={this.state.CostLastYear} onChange={this.handleInputChange} />


                        <br />

                        <label>CostYTD: </label>   
                        <input name="CostYTD" type="text" value={this.state.CostYTD} onChange={this.handleInputChange} />


                        <br />
                        <br />
                        
                        <input type="submit" value="Save" />
                        <button onClick={this.closeModal}>Close</button>
                    </form>
                </Modal>

                SalesLastYear: SalesLastYear,
                SalesYTD: SalesYTD,
                CostLastYear: CostLastYear,
                CostYTD: CostYTD,
                detailRecords: detailRecords
            </div>
            )
    }

};
