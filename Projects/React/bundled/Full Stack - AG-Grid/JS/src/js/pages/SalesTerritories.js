'use strict';

import React from "react";
import {render} from "react-dom";

import SalesTerritoryMasterGrid from "../components/SalesTerritoryMasterGrid.jsx";

import { getSalesTerritories } from "../services/DataService";

export default class Archives extends React.Component {
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
        const { query } = this.props.location;
        const { params } = this.props;
        const { article } = params;
        const { date, filter } = query;
    
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
        var self = this;
        
        return (
            <div>
            <h1>SalesTerritories</h1>
            <div class="row">{self.state.ErrorsOccurred ? self.state.ErrorMessage : self.state.Grid}</div>
            <br/><br/>
            </div>
        );
    }

}
