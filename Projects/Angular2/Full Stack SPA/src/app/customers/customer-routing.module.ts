import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CustomerListComponent }       from './customer-list.component';
import { CustomerDetailComponent }     from './customer-detail.component';

import { CanDeactivateGuard }     from '../can-deactivate-guard.service';

const customerRoutes: Routes = [
  { path: 'customers', redirectTo: '/supercustomers' },
  { path: 'customer/:id', redirectTo: '/supercustomer/:id' },
  { path: 'supercustomers',  component: CustomerListComponent },
  { path: 'supercustomer/:id', component: CustomerDetailComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(customerRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class CustomerRoutingModule { }
