import { NgModule }       from '@angular/core';
import { FormsModule }    from '@angular/forms';
import { CommonModule }   from '@angular/common';
import { CustomerService }        from './customer.service';
import { CustomerComponent }        from './customer.component';
import { CustomerListComponent }    from './customer-list.component';
import { CustomerHomeComponent }    from './customer-home.component';
import { CustomerDetailComponent }  from './customer-detail.component';

import { CustomerRoutingModule } from './customer-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CustomerRoutingModule
  ],
  declarations: [
    CustomerComponent,
    CustomerListComponent,
    CustomerHomeComponent,
    CustomerDetailComponent
  ],
  providers: [
    CustomerService
  ]
})
export class CustomerModule {}
