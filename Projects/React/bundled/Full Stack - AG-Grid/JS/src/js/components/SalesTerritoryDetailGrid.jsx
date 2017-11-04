import React, {Component} from "react";
import {AgGridReact} from "ag-grid-react";
import "./styles/agGridStyles.css";
import {formatDate, formatCurrency} from "../utilities/Common.js";
import SalesTerritoryDetailGridTemplate from "./SalesTerritoryDetailGridTemplate.jsx";
import RepeaterComponent from 'repeater-react';
//import react-native-hr 
export default class SalesTerritoryDetailGrid extends Component {
    constructor(props) {
        super(props);
        this.state = {
            parentRecord: this.props.node.parent.data,
            img: "data:image/jpeg;base64, " + this.props.node.parent.data.detailRecords.Photo
        };
        this.onSearchTextChange = this.onSearchTextChange.bind(this);

        // override the containing div so that the child grid fills the row height
        this.props.reactContainer.style.height = "100%";

        console.log("this.props.node.parent.data", this.props.node.parent.data);
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

    myComponentProps = {
        class: 'MyCSSclass'
        //..Any other prop you have to pass to your component
    }

    render() {
        let dateFormat = "mm/dd/yyyy";

        if (this.state.parentRecord.detailRecords[0])
        {
            let records = this.state.parentRecord.detailRecords;
            let rows = [];
            let line = null;
            
            var salesPersons = records.map(function( detailRecord, i){
                if (i==0) {
                    line =     <hr />;
                }
                else {
                  //  line =     <br />;                    
                    line = null;                    
                }
            return (
              <div key={i}>
                  {line}
                <div class="col-lg-12" >
                    <div class="col-lg-3">
                        {/* <div className="full-width-detail">i = {i}</div> */}
                        <div className="full-width-detail"><img width="120px" height="130px" src={"data:image/jpeg;base64, " + detailRecord.Person.Photo} alt="Customer Photo" style={{border:'2px solid gold'}}/></div>
                        {/* <div className="full-width-detail">{detailRecord.ID}</div> */}
                        <div className="full-width-detail">{detailRecord.Person.Name}</div>
                    </div>

                    <div class="col-lg-5">
                        <div className="full-width-detail" style={{padding:'10px'}}><b>Address: </b> {detailRecord.Person.Address}</div>
                        <div className="full-width-detail" style={{padding:'10px'}}><b>EmailAddress: </b> {detailRecord.Person.EmailAddress}</div>
                        <div className="full-width-detail" style={{padding:'10px'}}><b>PhoneNumber: </b> {detailRecord.Person.PhoneNumber}</div>
                    </div>

                    <div class="col-lg-4">
                        <div className="full-width-detail" style={{padding:'10px'}}><b>SalesQuota: </b> {formatCurrency(detailRecord.SalesQuota)}</div>
                        <div className="full-width-detail" style={{padding:'10px'}}><b>Bonus: </b> {formatCurrency(detailRecord.Bonus)}</div>
                        <div className="full-width-detail" style={{padding:'10px'}}><b>CommissionPct: </b> {formatCurrency(detailRecord.CommissionPct)}</div>
                        <div className="full-width-detail" style={{padding:'10px'}}><b>SalesYTD: </b> {formatCurrency(detailRecord.SalesYTD)}</div>
                        <div className="full-width-detail" style={{padding:'10px'}}><b>SalesLastYear: </b> {formatCurrency(detailRecord.TotalPurchaseYTD)}</div>
                    </div>
                
                </div>
                <hr />

              </div>
            );
        })
            return (
                <div>
                    {salesPersons}
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
