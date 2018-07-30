'use strict';

import React from "react";
import {render} from "react-dom";

import SalesTerritoryMasterGrid from "../components/SalesTerritoryMasterGrid.jsx";

import { getSalesTerritories } from "../services/DataService";

export default class SalesTerritories extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            SalesTerritories: [],
            ErrorsOccurred: false,
            ErrorMessage: "",
            Grid: null
        };
    }
    
    componentDidMount() {
        var salesTerritoryPromise = getSalesTerritories();
        var self = this;
        
        salesTerritoryPromise
        .then(function (response) {

            self.setState({
                Grid: <SalesTerritoryMasterGrid rows={response}/>
            });
        })
       .catch(function (error) {
            console.log("error", error);
            self.setState({
                ErrorsOccurred: true,
                ErrorMessage: error.toString()
                });
       });
    }
    
    render() {
        console.log("SalesTerritories");

        var self = this;
        
        return (
            <div>
            <div className="row">{self.state.ErrorsOccurred ? self.state.ErrorMessage : self.state.Grid}</div>
            <br/><br/>
            </div>
        );
    }

}
