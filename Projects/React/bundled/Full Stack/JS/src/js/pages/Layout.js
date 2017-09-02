import React from "react";
import { Link } from "react-router";

import Footer from "../components/layout/Footer";
import Nav from "../components/layout/Nav";

export default class Layout extends React.Component {

navigate() {
  this.props.history.pushState(null, "/");
 // this.props.history.Component.replaceState(null, "/");
}

  render() {
    const { location } = this.props;
    const containerStyle = {
      marginTop: "60px"
    };

    console.log("layout page");
    console.log("this.props.children", this.props.children);
    console.log("this.props", this.props);
    
    return (
      <div>

        <Nav location={location} />

        <div class="container" style={containerStyle}>
          <div class="row">
            <div class="col-lg-12">
              <h1>KillerNews.net</h1>

{/*               <button class="btn btn-info" onClick={this.navigate.bind(this)}>featured</button>
              <Link to="archives" class="btn btn-danger">archives</Link>
              <Link to="settings"> <button class="btn btn-success">settings</button></Link>
 */}
              {this.props.children}
              
            </div>
          </div>
          <Footer/>
        </div>
      </div>

    );
  }
}
