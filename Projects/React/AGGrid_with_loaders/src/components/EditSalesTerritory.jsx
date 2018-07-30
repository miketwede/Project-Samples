import React, {Component} from "react";
import {AgGridReact} from "ag-grid-react";
import {AgGrid} from "ag-grid";
import SalesTerritoryDetailGrid from "./SalesTerritoryDetailGrid.jsx";
import * as common from "../utilities/Common.js";

export default class EditSalesTerritory extends Component {

    constructor(props) {
        super(props);

        this.state = {
            dateFormat: "mm/dd/yyyy"
        };
    }

    render() {
        let containerStyle = {
            height: 650,
            width: 1500
        };

        return (
            <div>
                <div>
                    <h1>Edit Sales Territory</h1>
                </div>
            </div>
            )
    }

};
