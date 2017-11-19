import { NgModule }       from '@angular/core';
import { FormsModule }    from '@angular/forms';
import { CommonModule }   from '@angular/common';

import { CustomerService }        from './customer.service';
import { CustomerListComponent }    from './customer-list.component';
import { CustomerDetailComponent }  from './customer-detail.component';
import { CustomerRoutingModule } from './customer-routing.module';

// ag-grid
import { AgGridModule }  from "ag-grid-angular";

// import { DomSanitizer } from '@angular/platform-browser';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CustomerRoutingModule,
    AgGridModule.withComponents([CustomerListComponent])
  ],
  declarations: [
    CustomerListComponent,
    CustomerDetailComponent
  ],
  providers: [CustomerService]
})
export class CustomerModule {}
