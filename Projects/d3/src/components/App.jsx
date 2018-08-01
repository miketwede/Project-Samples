import React, { Component } from "react";
import ReactDOM from "react-dom";
//import {Route,  NavLink,  HashRouter} from "react-router-dom";
import { Route,  NavLink,  BrowserRouter } from 'react-router-dom'

import Archives from "../pages/Archives";
import Featured from "../pages/Featured";
import Layout from "../pages/Layout";
import Settings from "../pages/Settings";
import Customers from "../pages/Customers";
import SalesTerritories from "../pages/SalesTerritories";
import Home from "../pages/Home";
import Blank from "../pages/Blank";
import Header from "../pages/Header";

import "./styles/index.css";

const App = () => {
  return (
    <BrowserRouter>
      <div>
        <h1>Simple SPA</h1>
            <div className="content">
              <Route path="/" component={Header}/>
              <Route path="/Home" component={Home}/>
              <Route path="/Customers" component={Customers}/>
              <Route path="/Featured" component={Featured}/>
              <Route path="/SalesTerritories" component={SalesTerritories}/>
              <Route path="/Settings" component={Settings}/>
            </div>
      </div>
    </BrowserRouter>
  );
};

export default App;
