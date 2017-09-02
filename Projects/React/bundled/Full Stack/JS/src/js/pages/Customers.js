import React from "react";

import Customer from "../components/Customer.js";

import { getCustomers } from "../services/DataService";

export default class Archives extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Customers: [],
            ErrorsOccurred: false,
            ErrorMessage: ""
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
            var customers = [];
            for (var i = 0; i < response.length; i++) { 
                var customer = <Customer key={i} row={response[i]}/>;
                customers.push(customer);
            }
            self.setState({
            Customers: customers
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
            <div class="row">{self.state.ErrorsOccurred ? self.state.ErrorMessage : self.state.Customers}</div>
            <br/><br/>
            </div>
        );
    }

}
