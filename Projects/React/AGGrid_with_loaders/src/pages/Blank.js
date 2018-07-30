import React from "react";
import { Route,  NavLink,  BrowserRouter } from 'react-router-dom'

import Home from "./Home";

export default class Blank extends React.Component {
  render() {
    console.log("blank");
    // this.context.history.push('/Home')
    return (
<div>
  </div>
    );
  }
}
