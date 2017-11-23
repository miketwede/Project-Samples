import {AfterViewInit, Component, Injectable } from "@angular/core";
import {GridOptions} from "ag-grid/main";
import {ICellRendererAngularComp} from "ag-grid-angular/main";
@Component({
  template: `
<div> hello </div>

  `
})

export class CustomerDetailGrid implements ICellRendererAngularComp, AfterViewInit {
    public gridOptions: GridOptions;
    public parentRecord: any;

  constructor(
  ) {
      //console.log("props", props);
      let mike = "";
    }


    agInit(params: any): void {
        this.parentRecord = params.node.parent.data;
    }

    // Sometimes the gridReady event can fire before the angular component is ready to receive it, so in an angular
    // environment its safer to on you cannot safely rely on AfterViewInit instead before using the API
    ngAfterViewInit() {
        this.gridOptions.api.setRowData(this.parentRecord.callRecords);
        this.gridOptions.api.sizeColumnsToFit();
    }

    refresh(): boolean {
        return false;
    }
  }
