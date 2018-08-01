import React, {Component} from "react";
import {AgGridReact} from "ag-grid-react";

////////////////import "./styles/agGridStyles.css";
import {formatDate, formatCurrency} from "../utilities/Common.js";

// import RepeaterComponent from 'repeater-react';

// pull in the ag-grid styles we're interested in
import 'ag-grid/dist/styles/ag-grid.css';
import 'ag-grid/dist/styles/theme-fresh.css';

 export default class SalesTerritoryDetailGridTemplate extends Component {
    // const SalesTerritoryDetailGridTemplate = React.createClass({
     //   class SalesTerritoryDetailGridTemplate extends React.Component{
            constructor(props) {
                super(props);
              }


    render() {
        let dateFormat = "mm/dd/yyyy";
        let detailRecord = this.props.detailRecord;

        return (
                <div className="full-width-panel">
                <div className="row">


                    <div className="col-lg-12" >
                        <div className="col-lg-3">
                        <div className="full-width-detail"><img width="120px" height="130px" src={"data:image/jpeg;base64, " + detailRecord.Person.Photo} alt="Customer Photo" style={{border:'2px solid gold'}}/></div>

                            {/* <div className="full-width-detail"><img width="120px" height="130px" src={detailRecord.Person.Photo} alt="Customer Photo" style={{border:'2px solid gold'}}/></div> */}
                            {/* <div className="full-width-detail"><b>Name: </b> {this.state.parentRecord.Name}</div> */}
                            <div className="full-width-detail">{detailRecord.ID}</div>
                            <div className="full-width-detail">{detailRecord.Person.Name}</div>
                            {/* <div className="full-width-detail"><b>Account: </b> {this.state.parentRecord.AccountNumber}</div> */}
                        </div>

                        <div className="col-lg-5">
                        {/* <div className="full-width-detail" style={{padding:'10px'}}><b>Photo: </b> {detailRecord.Person.Photo}</div> */}
                        <div className="full-width-detail" style={{padding:'10px'}}><b>Address: </b> {detailRecord.Person.Address}</div>
                        <div className="full-width-detail" style={{padding:'10px'}}><b>EmailAddress: </b> {detailRecord.Person.EmailAddress}</div>
                        <div className="full-width-detail" style={{padding:'10px'}}><b>PhoneNumber: </b> {detailRecord.Person.PhoneNumber}</div>
                        </div>

   

                        <div className="col-lg-4">
                            <div className="full-width-detail" style={{padding:'10px'}}><b>SalesQuota: </b> {formatCurrency(detailRecord.SalesQuota)}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>Bonus: </b> {formatCurrency(detailRecord.Bonus)}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>CommissionPct: </b> {formatCurrency(detailRecord.CommissionPct)}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>SalesYTD: </b> {formatCurrency(detailRecord.SalesYTD)}</div>
                            <div className="full-width-detail" style={{padding:'10px'}}><b>SalesLastYear: </b> {formatCurrency(detailRecord.TotalPurchaseYTD)}</div>
                        </div>
                    </div>

                    </div>
                </div>
                            );
            }

        };
        
        // SalesTerritoryDetailGridTemplate.propTypes = {
            
        //     };
        // SalesTerritoryDetailGridTemplate.defaultProps = {
        
        // };

      //  export default SalesTerritoryDetailGridTemplate;
// }