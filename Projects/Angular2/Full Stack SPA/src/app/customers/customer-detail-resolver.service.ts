import 'rxjs/add/operator/map';
import 'rxjs/add/operator/take';
import { Injectable }             from '@angular/core';
import { Observable }             from 'rxjs/Observable';
import { Router, Resolve, RouterStateSnapshot,
         ActivatedRouteSnapshot } from '@angular/router';

import { Customer, CustomerService }  from './customer.service';

@Injectable()
export class CustomerDetailResolver implements Resolve<Customer> {
  constructor(private cs: CustomerService, private router: Router) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Customer> {
    let id = route.paramMap.get('id');

    // return this.cs.getCustomer(id).take(1).map(customer => {
    //   if (customer) {
    //     return customer;
    //   } else { // id not found
    //     this.router.navigate(['/customer']);
    //     return null;
    //   }
    // });

    return this.cs.getCustomer(id).map(customer => {
      if (customer) {
        return customer;
      } else { // id not found
        this.router.navigate(['/customer']);
        return null;
      }
    });
  }
}
