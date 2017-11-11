import 'rxjs/add/operator/switchMap';
import { Component, OnInit }        from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';

// import { Customer, CustomerService } from './customer.service';
import { Customer, CustomerService } from './customer.service';
import { Observable }            from 'rxjs/Observable';
import { httpServices }           from '../../services/httpServices';

// client
//import { HttpClient } from "../services/client"

// interface
//import { IUser } from "../services/interfaces"

@Component({
  template: `
    <ul class="items">
      <li *ngFor="let customer of customers$ | async"
        [class.selected]="customer.customerID === selectedId">
        <a [routerLink]="[customer.customerID]">
          <span class="badge">{{ customer.customerID }}</span>{{ customer.accountNumber }}
        </a>
      </li>
    </ul>

    <router-outlet></router-outlet>
  `
})
export class CustomerListComponent implements OnInit {
  // customers$: Observable<CustomerService.customers$>;
  //customers$: Observable<CustomerService.customers$>;
  customers$: Observable<any>;
  selectedId: number;

  constructor(
    private service: CustomerService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    // this.customers$ = this.route.paramMap
    //   .switchMap((params: ParamMap) => {
    //     this.selectedId = +params.get('customerID');
    //     return this.service.getCustomers();
    //   });

    this.customers$ = this.service.getCustomers();
    };


  }

