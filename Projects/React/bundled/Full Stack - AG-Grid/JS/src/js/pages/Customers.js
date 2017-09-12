'use strict';

import React from "react";
import {render} from "react-dom";

import CustomerMasterGrid from "../components/CustomerMasterGrid.jsx";

import { getCustomers } from "../services/DataService";

export default class Archives extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Customers: [],
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
    
        var customerPromise = getCustomers();
        var self = this;
        
        customerPromise
        .then(function (response) {

            self.setState({
                Grid: <CustomerMasterGrid rows={response}/>
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
            <h1>Customers</h1>
            <div class="row">{self.state.ErrorsOccurred ? self.state.ErrorMessage : self.state.Grid}</div>
            <br/><br/>
            </div>
        );
    }

}
