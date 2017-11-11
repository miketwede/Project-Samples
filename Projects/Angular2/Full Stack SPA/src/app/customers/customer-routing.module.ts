import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CustomerHomeComponent } from './customer-home.component';
import { CustomerListComponent }       from './customer-list.component';
import { CustomerComponent }     from './customer.component';
import { CustomerDetailComponent }     from './customer-detail.component';

import { CanDeactivateGuard }     from '../can-deactivate-guard.service';
import { CustomerDetailResolver }   from './customer-detail-resolver.service';

const customerRoutes: Routes = [
  {
    path: '',
    component: CustomerComponent,
    children: [
      {
        path: '',
        component: CustomerListComponent,
        children: [
          {
            path: ':id',
            component: CustomerDetailComponent,
            canDeactivate: [CanDeactivateGuard],
            resolve: {
              crisis: CustomerDetailResolver
            }
          },
          {
            path: '',
            component: CustomerHomeComponent
          }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(customerRoutes)
  ],
  exports: [
    RouterModule
  ],
  providers: [
    CustomerDetailResolver
  ]
})
export class CustomerRoutingModule { }
