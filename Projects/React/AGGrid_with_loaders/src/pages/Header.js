import React from "react";
import "../components/styles/index.css";
import { Route,  NavLink,  BrowserRouter } from 'react-router-dom'

export default class Header extends React.Component {
  render() {
    console.log("Header");
    return (
        <ul className="header">
        <li><NavLink to="/Home" replace={true} >Home</NavLink></li>
        <li><NavLink to="/Customers" replace={true} >Customers</NavLink></li>
        <li><NavLink to="/Featured" replace={true} >Featured</NavLink></li>
        <li><NavLink to="/SalesTerritories" replace={true} >SalesTerritories</NavLink></li>
        <li><NavLink to="/Settings" replace={true} >Settings</NavLink></li>
        </ul>
    );
  }
}
