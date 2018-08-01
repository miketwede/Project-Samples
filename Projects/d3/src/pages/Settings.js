import React from "react";
//import d3 from "d3";
import * as d3 from "d3";

export default class Settings extends React.Component {
  render() {
    console.log("settings");

    d3.select("body").transition().style("background-color", "black");

    return (
      <h1>Settings</h1>
    );
  }
}
