import React from "react";

export default class Customer extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      showAdditionalInfo: false,
      buttonState: "none",
      buttonText: "More info"      
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
      if (this.state.buttonState == "none") {
        this.setState({ buttonState: "block", buttonText: "Less info" })        
      }
      else {
        this.setState({ buttonState: "none", buttonText: "More info" })        
      }
    }

    return (
      <div >
        <h2>Hello {name}! </h2>
        <div id="additionalInfo" name="additionalInfo" style={{display : this.state.buttonState}} >
          <h4 >Age: {row.Age} years old.</h4>
          <h4 >Address: { address }.</h4>
          <h4 >Occupation: {row.Occupation}.</h4>
          <h4 >Hobbies: {row.Hobbies}.</h4>
        </div>
        <button type="button" class="btn btn-default" onClick={toggleMoreInfo.bind(this)}  >{this.state.buttonText}</button>
      </div>
    );


  }
}
