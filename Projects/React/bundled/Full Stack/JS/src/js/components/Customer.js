import React from "react";
import ToggleDisplay from 'react-toggle-display';

export default class Customer extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      buttonText: "More info",      
      showMore: false     
    };
}
  
  render() {
    console.log("in  Customer()");
    console.log("this.props", this.props);

    const { row } = this.props;
    console.log("row", row);

    const name = row.Title + " " + row.FirstName + " " + row.MiddleInitial + " " + row.LastName + " " + row.Suffix;
    const address = row.Address1 + " " + row.Address2 + " " + row.City + ", " + row.State + "   " + row.Zip + "   " + row.Country;
    
    function toggleMoreInfo()
    {
      this.setState({
        showMore: !this.state.showMore,
        buttonText: this.state.showMore ? "More info" : "Less info"
      });
    }

    return (
      <div >
        <h3> Name: <b>{name}</b> </h3>
        <h3> Address: {address} </h3>
        <h3> Email: {row.EmailAddress} </h3>
        <h3> Phone: {row.PhoneNumber} </h3>
        <ToggleDisplay show={this.state.showMore}>
          <h4 >TotalPurchaseYTD: { row.Demographics.TotalPurchaseYTD} </h4>
          <h4 >DateFirstPurchase: { row.Demographics.DateFirstPurchase} </h4>
          <h4 >BirthDate: { row.Demographics.BirthDate} </h4>
          <h4 >MaritalStatus: { row.Demographics.MaritalStatus} </h4>
          <h4 >YearlyIncome: { row.Demographics.YearlyIncome} </h4>
          <h4 >Gender: { row.Demographics.Gender} </h4>
          <h4 >TotalChildren: { row.Demographics.TotalChildren} </h4>
          <h4 >NumberChildrenAtHome: { row.Demographics.NumberChildrenAtHome} </h4>
          <h4 >Education: { row.Demographics.Education} </h4>
          <h4 >Occupation: { row.Demographics.Occupation} </h4>
          <h4 >HomeOwnerFlag: { row.Demographics.HomeOwnerFlag} </h4>
          <h4 >NumberCarsOwned: { row.Demographics.NumberCarsOwned} </h4>
          <h4 >CommuteDistance: { row.Demographics.CommuteDistance} </h4>
        </ToggleDisplay>
        <button type="button" class="btn btn-default" onClick={toggleMoreInfo.bind(this)}  >{this.state.buttonText}</button>
      </div>
    );


  }
}
