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

    const name = row.FirstName + " " + row.LastName;
    const address = row.Address1 + " " + row.Address2 + " " + row.City + ", " + row.State + "   " + row.Zip;
    
    function toggleMoreInfo()
    {
      this.setState({
        showMore: !this.state.showMore,
        buttonText: this.state.showMore ? "More info" : "Less info"
      });
    }

    return (
      <div >
        <h2>Hello {name}! </h2>
        <ToggleDisplay show={this.state.showMore}>
          <h4 >Age: {row.Age} years old.</h4>
          <h4 >Address: { address }.</h4>
          <h4 >Occupation: {row.Occupation}.</h4>
          <h4 >Hobbies: {row.Hobbies}.</h4>
          </ToggleDisplay>
        <button type="button" class="btn btn-default" onClick={toggleMoreInfo.bind(this)}  >{this.state.buttonText}</button>
      </div>
    );


  }
}
