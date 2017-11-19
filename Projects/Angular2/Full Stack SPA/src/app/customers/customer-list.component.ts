import 'rxjs/add/operator/switchMap';
import { Observable }                             from 'rxjs/Observable';
import { Component, OnInit }                      from '@angular/core';
import { ActivatedRoute, ParamMap }               from '@angular/router';
import {DomSanitizer}                             from '@angular/platform-browser';

import { Customer, CustomerService, ICustomer }   from './customer.service';
import { httpServices }                           from '../../services/httpServices';
import { Common }                                 from '../../utilities/Common';

// ag-grid
 import {GridOptions} from "ag-grid/main";
// import {GridOptions} from "ag-grid";
// import {AgGridNg2, AgGridModule} from "ag-grid-angular";
//import {GridOptions} from "ag-grid";
//import {AgGrid} from "ag-grid";


@Component({
  template: `
    <h1>Customers</h1>

    
<ag-grid-angular 
  class="ag-theme-fresh"
  style="width: 100%; height: 400px;" 
  [gridOptions]="this.gridOptions"

  
  enableColResize
  enableSorting
  enableFilter
  groupHeaders
  suppressRowClickSelection
  toolPanelSuppressGroups
  toolPanelSuppressValues
  rowHeight="22"
  rowSelection="multiple"
  >
  </ag-grid-angular>

  
  `
})
export class CustomerListComponent implements OnInit {
  public gridOptions: GridOptions;
  public rowData: any[] = [];
  public columnDefs: any[] = [];


  //customers$: Observable<ICustomer>;
  public customers$: Observable<any>;
  public selectedId: number;
  public expanded = false;
  public dateFormat = "mm/dd/yyyy";

  // rowData: ICustomer[];
  public customers: any[];
  
  constructor(
    public service: CustomerService,
    public route: ActivatedRoute,
    public common: Common,
    public _DomSanitizer: DomSanitizer
  ) {

        // we pass an empty gridOptions in, so we can grab the api out
        this.gridOptions = <GridOptions>{
          floatingFilter: true,
          rowData: this.rowData,
          columnDefs: this.columnDefs
        };
        this.columnDefs = this.createColumnDefs();
        this.createRowData();

        // this.gridOptions.dateComponentFramework = DateComponent;
        // this.gridOptions.defaultColDef = {
        //     headerComponentFramework: <{ new(): HeaderComponent }>HeaderComponent,
        //     headerComponentParams: {
        //         menuIcon: 'fa-bars'
        //     }
        // };
        // this.gridOptions.getContextMenuItems = this.getContextMenuItems.bind(this);
        this.gridOptions.floatingFilter = true;
        this.gridOptions.rowData = this.rowData;
        this.gridOptions.columnDefs = this.columnDefs;
        



}

      // {
      //     headerName: 'Name', field: 'Name', width: 100, filter: "text",
      //     // left column is going to act as group column, with the expand / contract controls
      //     cellRenderer: 'group',
      //     // we don't want the child count - it would be one each time anyway as each parent
      //     // not has exactly one child node
      //     cellRendererParams: {suppressCount: true}
      // },

      // {headerName: "IndividualSurvey", field: "detailRecord", width: 900}
      
createColumnDefs() {
  return [
      {headerName: "Name", field: "Name", width: 300},
      {headerName: "Phone", field: "Phone", width: 150},
      {headerName: "Email", field: "Email", width: 300},
      {headerName: "AccountNumber", field: "AccountNumber", width: 175, filter: "text"},
      {headerName: "Address", field: "Address", width: 500}
  ];
}

createRowData() {
  this.customers = [];
  let rows = [];
  let $rows = this.service.getCustomers();
  this.gridOptions.rowData = [];
  $rows.subscribe(
    res => {
      rows = res;
      console.log("this.rows", rows, "end");

      for (let i = 0; i < rows.length; i++) {
        let Name = this.common.formatName(rows[i].person); 
        let Phone = rows[i].person.phoneNumber;
        let Email = rows[i].person.emailAddress;
        let AccountNumber = rows[i].accountNumber;
        let Address = this.common.formatAddress(rows[i].person);
        let Photo = rows[i].person.photo;
        let IndividualSurvey = rows[i].demographics;
        
        let detailRecords = [];
        if (IndividualSurvey){
            let detailRecord = {
            TotalPurchaseYTD: IndividualSurvey.totalPurchaseYTD,
            DateFirstPurchase: IndividualSurvey.dateFirstPurchase,
            BirthDate: IndividualSurvey.birthDate,
            MaritalStatus: IndividualSurvey.maritalStatus,
            YearlyIncome: IndividualSurvey.yearlyIncome,
            Gender: IndividualSurvey.gender,
            TotalChildren: IndividualSurvey.totalChildren,
            NumberChildrenAtHome: IndividualSurvey.numberChildrenAtHome,
            Education: IndividualSurvey.education,
            Occupation: IndividualSurvey.occupation,
            HomeOwnerFlag: IndividualSurvey.homeOwnerFlag,
            NumberCarsOwned: IndividualSurvey.numberCarsOwned,
            CommuteDistance: IndividualSurvey.commuteDistance
            };
            detailRecords.push(detailRecord);
        }
  
  
        // let masterRecord = {
        //     Name: Name,
        //     Phone: Phone,
        //     Email: Email,
        //     AccountNumber: AccountNumber,
        //     Address: Address,
        //     Photo: Photo,
        //     detailRecords: detailRecords
        // };
  
        let masterRecord = {
          Name: Name,
          Phone: Phone,
          Email: Email,
          AccountNumber: AccountNumber,
          Address: Address
      };

      this.rowData.push(masterRecord);
    }
    console.log("CONSOLE: createRowData  this.rowData;", this.rowData, "end");
    console.log("CONSOLE: createRowData  this.columnDefs;", this.columnDefs, "end");

    this.gridOptions.api.setRowData(this.rowData);

    //this.gridOptions.rowData = this.rowData;
    
   // this.gridOptions.api.redrawRows();

//    var params = {
//     force: true
// };
// this.gridOptions.api.refreshCells(params);

   // this.rowData = this.customers;
  //   this.gridOptions = <GridOptions>{
  //     rowData: this.customers,
  //     columnDefs: this.createColumnDefs(),
  //     context: {
  //         componentParent: this
  //     },
  //     enableColResize: true
  // };

    //return this.rowData;
    },
    err => {
        console.error(err);
        //return this.rowData;
        
    }
    
  );
  console.log("outside return this.customers;", this.customers, "end");
  
  //return this.rowData;
  
}

onRowDataChanged(params){

console.log("params", params);
}

     onGridReady(params) {
         params.api.sizeColumnsToFit();
    // this.gridApi = params.api;
    // this.columnApi = params.columnApi;

    // this.gridApi.sizeColumnsToFit();
    }

    selectAllRows() {
        this.gridOptions.api.selectAll();
    }

    onRowClicked($event) {
      //let id = this.listData[row]['id'] //presuming id is an attribute in your data
      // do something, ie show detail
      // ....
    };

  ngOnInit() {
    //this.createRowData();
    // this.customers$ = this.service.getCustomers();
    // console.log("CONSOLE2: ngOnInit this.customers$;", this.customers$, "end");
    
    //  this.customers$.subscribe(val => {
    //    this.customers = val;
    //    console.log("CONSOLE2 this.customers;", this.customers, "end");


    // console.log("CONSOLE2: this.gridOptions", this.gridOptions, "end");
    // console.log("CONSOLE2: this.customers;", this.customers, "end");
    
    //  }
    // );
    // this.customers$.subscribe(val => console.log("CONSOLE: Val", val, "end"));
    // //this.service.getCustomers().subscribe(val => this.customers = val);
    // //this.createRowData();
    // //console.log("this.rowData",this.rowData);
    console.log("CONSOLE2: ngOnInit  this.rowData;", this.rowData, "end");
    console.log("CONSOLE2: ngOnInit  this.columnDefs;", this.columnDefs, "end");
    console.log("CONSOLE2: ngOnInit  this.gridOptions;", this.gridOptions, "end");
    
    // this.customers$.subscribe(this.customers => console.log("CONSOLE: this.customers", this.customers, "end"));
    };

  formatYTD(amount) {
    if (!amount) {
      return null;
      }
    else {
      return this.common.formatCurrency(amount.substring(0, amount.indexOf('-'))) + "-" + this.common.formatCurrency(amount.substring(amount.indexOf('-')+1, amount.length));
      }
  }

  getSafeImgString(image) {
      return this._DomSanitizer.bypassSecurityTrustResourceUrl("data:image/jpeg;base64, " + image);
    }

  }
/*   <ag-grid-angular style="width: 900px; height: 420px;" class="ag-theme-fresh"
  [gridOptions]="this.gridOptions">
</ag-grid-angular> */