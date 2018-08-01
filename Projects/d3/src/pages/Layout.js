import React from "react";
import { Link } from "react-router";

import Footer from "../components/layout/Footer";
import Nav from "../components/layout/Nav";
import {formatDate, formatCurrency} from "../utilities/Common.js";

export default class Layout extends React.Component {

navigate() {
  this.props.history.pushState(null, "/");
 // this.props.history.Component.replaceState(null, "/");
}

  render() {
    const { location } = this.props;
    // const containerStyle = {
    //   marginTop: "60px"
    // };
    let containerStyle = {
      marginTop: "60px",
      height: 650,
      width: 1500
  };
    let dateFormat = "mm/dd/yyyy";
    
    return (
      <div>

        <Nav location={location} />

        <div className="container" style={containerStyle}>
          <div className="row">

            <div className="col-lg-12" style={{height:70}}>
              <div className="col-lg-11" style={{height:70}}>
                <h1>KillerNews.net</h1>
              </div>
              <div className="col-lg-1" style={{height:70}}>
              {/* <h4 class="div.relative">{formatDate(Date.now(), dateFormat)}</h4> */}
              <h4 className="div.absolute" > <br/></h4>
              <h4 className="div.absolute" >{formatDate(Date.now(), dateFormat)}</h4>
              </div>
            </div>
            
            {this.props.children}

          </div>
        </div>

        <Footer/>

      </div>

    );
  }
}
