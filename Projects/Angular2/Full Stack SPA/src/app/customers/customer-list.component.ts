import 'rxjs/add/operator/switchMap';
import { Observable }                             from 'rxjs/Observable';
import { Component, OnInit, ComponentFactoryResolver, ReflectiveInjector, Injectable  }                      from '@angular/core';
import { ActivatedRoute, ParamMap, Router }               from '@angular/router';
import {DomSanitizer}                             from '@angular/platform-browser';

import { Customer, CustomerService, ICustomer }   from './customer.service';
import { httpServices }                           from '../../services/httpServices';
import { Common }                                 from '../../utilities/Common';

// import {CustomerDetailGrid} from "./CustomerDetailGrid.component";
import {CustomerModule} from "./customer.module";
import {CustomerDetailGrid} from "./CustomerDetailGrid.component";

// ag-grid
 import {GridOptions} from "ag-grid/main";
// import {GridOptions} from "ag-grid";
// import {AgGridNg2, AgGridModule} from "ag-grid-angular";
//import {GridOptions} from "ag-grid";
//import {AgGrid} from "ag-grid";

// groupHeaders
// suppressRowClickSelection
// toolPanelSuppressGroups
// toolPanelSuppressValues
// rowHeight="22"
// rowSelection="multiple"

// [getNodeChildDetails]="this.getNodeChildDetails()"
// [fullWidthCellRendererFramework]="getFullWidthCellRenderer()"

// getNodeChildDetails={{this.getNodeChildDetails()}}
// fullWidthCellRendererFramework={{CustomerDetailGrid()}}

// enableColResize
// enableSorting
// enableFilter

@Component({
  template: `
    <h1>{{title}}</h1>

    
<ag-grid-angular 
  class="ag-fresh"
  style="width: 100%; height: 400px;" 
  [gridOptions]="this.gridOptions"

  [isFullWidthCell]="this.isFullWidthCell"
  [getRowHeight]="this.getRowHeight"



  enableSorting
  enableFilter
  enableColResize

  >
  </ag-grid-angular>

  
  `
})
//(onRowClicked) = "onRowClicked"
//
//  (GridReady)="this.onGridReady"

// [getNodeChildDetails]="this.getNodeChildDetails"
// [fullWidthCellRendererFramework]="this.getFullWidthCellRenderer"

  // getNodeChildDetails={this.getNodeChildDetails}
  // fullWidthCellRendererFramework={CustomerDetailGrid}

  @Injectable()
export class CustomerListComponent implements OnInit {
  public gridOptions: GridOptions;
  public rowData: any[] = [];
  public columnDefs: any[] = [];


  //customers$: Observable<ICustomer>;
  public customers$: Observable<any>;
  public selectedId: number;
  public expanded = false;
  public dateFormat = "mm/dd/yyyy";
  public title = "Customers";
  
  // rowData: ICustomer[];
  public customers: any[];
  
  constructor(
    public service: CustomerService,
    public route: ActivatedRoute,
    public common: Common,
    public _DomSanitizer: DomSanitizer,
    private resolver: ComponentFactoryResolver,
    private router: Router
    // public customerDetailGrid:CustomerDetailGrid
  ) {
// this.router = router;
        // we pass an empty gridOptions in, so we can grab the api out
        this.gridOptions = <GridOptions>{
          floatingFilter: true,
          rowData: undefined,
          columnDefs: this.columnDefs,
          context: {
            componentParent: this
          },
          onRowClicked:this.onRowClicked
        };

        this.columnDefs = this.createColumnDefs();
        this.createRowData();

        this.gridOptions.floatingFilter = true;
        this.gridOptions.rowData = this.rowData;
        this.gridOptions.columnDefs = this.columnDefs;
        //this.gridOptions.groupRowInnerRendererFramework = CustomerDetailGrid;
        //this.gridOptions.groupRowInnerRendererFramework = new(CustomerDetailGrid) ;
        //this.gridOptions.groupRowInnerRendererFramework = this.getGroupRowInnerRendererFramework(CustomerDetailGrid) ;
        this.gridOptions.onGridReady = () => {
            this.gridOptions.api.sizeColumnsToFit();
        };
        this.gridOptions.getNodeChildDetails = this.getNodeChildDetails;

    }



    getGroupRowInnerRendererFramework(CustomerDetailGrid)
    {
        // We create an injector out of the data we want to pass down and this components injector
        // let injector = ReflectiveInjector.fromResolvedProviders(CustomerListComponent, this.dynamicSectionComponentContainer.parentInjector);
        var injector = ReflectiveInjector.resolveAndCreate([CustomerListComponent, CustomerDetailGrid]);
        var customerListComponent = injector.get(CustomerListComponent);
            // console.log("about to factory:");
            // // We create a factory out of the component we want to create
            // let factory = this.resolver.resolveComponentFactory(CustomerDetailGrid);
            // console.log("factory:" + factory);
        
            // // We create the component using the factory and the injector
            // let component:any = factory.create(injector);

return customerListComponent;
    }


createColumnDefs() {
  return [
    {
      headerName: 'Name', field: 'Name', width: 300, filter: "text",
      // left column is going to act as group column, with the expand / contract controls
      cellRenderer: 'group',
      // we don't want the child count - it would be one each time anyway as each parent
      // not has exactly one child node
      cellRendererParams: {suppressCount: true}
    },
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
        let CustomerID = rows[i].customerID; 
        let Name = this.common.formatName(rows[i].person); 
        let Phone = rows[i].person.phoneNumber;
        let Email = rows[i].person.emailAddress;
        let AccountNumber = rows[i].accountNumber;
        let Address = this.common.formatAddress(rows[i].person);
        let Photo = rows[i].person.photo;
        let IndividualSurvey = rows[i].demographics;
        
        let detailRecords = []; // one-to-one relationship between customer and survey
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
  
  
        let masterRecord = {
          CustomerID: CustomerID,
          Name: Name,
          Phone: Phone,
          Email: Email,
          AccountNumber: AccountNumber,
          Address: Address,
          Photo: Photo,
          detailRecords: detailRecords
        };
  
      this.rowData.push(masterRecord);
    }
    console.log("CONSOLE: createRowData  this.rowData;", this.rowData, "end");
    console.log("CONSOLE: createRowData  this.columnDefs;", this.columnDefs, "end");


    


    this.gridOptions.api.setRowData(this.rowData); // refreshes the grid

    ////////////////////////this.gridOptions.api.refreshCells();

    // this.gridOptions.rowData = this.rowData; // crashes the grid
    // this.gridOptions.rowData.concat(this.rowData); // crashes the grid
    // this.gridOptions.api.updateRowData(this.rowData); // refreshes the grid
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



    //  onGridReady(params) {
    //      params.api.sizeColumnsToFit();
    // // this.gridApi = params.api;
    // // this.columnApi = params.columnApi;

    // // this.gridApi.sizeColumnsToFit();
    // }

    selectAllRows() {
        this.gridOptions.api.selectAll();
    }

    onRowClicked($event) {
      //let id = this.listData[row]['id'] //presuming id is an attribute in your data
      // do something, ie show detail
      // ....
      console.log("$event", $event);
      // this.router.navigate(['./SomewhereElse']);
      // $event.context.componentParent.router.navigate(['customer/:{{$event.context.componentParent.router.navigations._value.id}}']);
      //$event.context.componentParent.router.navigate(['customer/:{{$event.data.customer.CustomerID}}']);

      $event.context.componentParent.router.navigate(["customer/"+$event.data.CustomerID]);
      // $event.context.componentParent.router.navigateByUrl(['customer/:{{$event.data.customer.CustomerID}}']);
      
    };

    public getFullWidthCellRenderer() {
      return CustomerDetailGrid;
  }

    minuteCellFormatter(params) {
      return params.value.toLocaleString() + 'm';
    };

    isFullWidthCell(rowNode) {
        return rowNode.level === 1;
    }

    getRowHeight(params) {
        let rowIsDetailRow = params.node.level === 1;
        // return 100 when detail row, otherwise return 25
        return rowIsDetailRow ? 200 : 25;
    }

    getNodeChildDetails(masterRecord) {
      
        if (masterRecord && masterRecord.detailRecords) {
          return {
              group: true,
              // the key is used by the default group cellRenderer
              key: masterRecord.Name,
              // provide ag-Grid with the children of this group
              children: [masterRecord.detailRecords]
              // for demo, expand the third row by default
             // expanded: record.account === 177002
          };
      } else {
          return null;
      }
  }

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