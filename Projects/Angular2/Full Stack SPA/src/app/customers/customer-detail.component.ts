import { Component, OnInit, HostBinding } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { slideInDownAnimation }   from '../animations';
import { CustomerService }         from './customer.service';
import { DialogService }  from '../dialog.service';


@Component({
  template: `
  <div *ngIf="customer$  | async as customer">
    <h3>"{{ customer.person.title + ' ' + customer.person.firstName + ' ' + customer.person.middleInitial + ' ' + customer.person.lastName + ' ' + customer.person.suffix }}"</h3>
    <div>
      <label>Id: </label>{{ customer.customerID }}</div>
      <div>
      <label>Account: </label>
      <input [(ngModel)]="customer.accountNumber" placeholder="account number"/>
    </div>
    <div>
      <label>Title: </label>
      <input [(ngModel)]="customer.person.title " placeholder="title"/>
    </div>
    <div>
    <label>First Name: </label>
    <input [(ngModel)]="customer.person.firstName " placeholder="first name"/>
    </div>
    <div>
      <label>Midle Initial: </label>
      <input [(ngModel)]="customer.person.middleInitial " placeholder="middle initial"/>
    </div>
    <div>
      <label>Last Name: </label>
      <input [(ngModel)]="customer.person.lastName " placeholder="last name"/>
    </div>
    <div>
      <label>Suffix: </label>
      <input [(ngModel)]="customer.person.suffix " placeholder="suffix"/>
    </div>

<p>
      <button (click)="save(customer)">Save</button>
      <button (click)="cancel(customer)">Cancel</button>
    </p>
  </div>
  `,
  styles: ['input {width: 20em}'],
  animations: [ slideInDownAnimation ]
})
export class CustomerDetailComponent implements OnInit {
  @HostBinding('@routeAnimation') routeAnimation = true;
  @HostBinding('style.display')   display = 'block';
  @HostBinding('style.position')  position = 'absolute';

  //customer: Customer;
  customer$: Observable<any>;
  //selectedCustomer: any;
  accountNumber: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    public dialogService: DialogService,
    private customerService: CustomerService    
  ) {}

  // ngOnInit() {
  //   this.route.data
  //     .subscribe((data: { customer: Customer }) => {
  //       this.accountNumber = data.customer.accountNumber;
  //       this.customer = data.customer;
  //     });
  // }

  ngOnInit() {
    this.customer$ = this.route.paramMap
      .switchMap((params: ParamMap) =>
        this.customerService.getCustomer(params.get('id')));

    this.customer$.subscribe(



      res => {
       // console.log("res", res);
        this.originalCustomer = res;
        console.log("this.originalCustomer", this.originalCustomer);
        
    },
    err => {
        console.error(err);
    }
    //console.log("mike5", mike5);
    





    );
   // console.log("mike5", mike5);

    //this.accountNumber = this.selectedCustomer.subscribe(accountNumber);
    

  }

  cancel(customer) {
    this.gotoCustomer();
  }

  save(customer) {
    this.customer$ = customer;
    this.gotoCustomer();
  }

  canDeactivate(): Observable<boolean> | boolean {
    // Allow synchronous navigation (`true`) if no customer or the customer is unchanged
    if (!this.customer$ || this.customer$.accountNumber === this.originalCustomer.accountNumber {
      return true;
    }
    // Otherwise ask the user with the dialog service and return its
    // observable which resolves to true or false when the user decides
    return this.dialogService.confirm('Discard changes?');
  }

  gotoCustomer() {
    let customerId = this.customer$ ? this.customer$.customerID : null;
    // Pass along the customer id if available
    // so that the CustomerListComponent can select that customer.
    // Add a totally useless `foo` parameter for kicks.
    // Relative navigation back to the crises
    // this.router.navigate(['../', { id: customerId, foo: 'foo' }], { relativeTo: this.route });
    this.router.navigate(['/customers', { id: customerId, foo: 'foo' }], { relativeTo: this.route });
    
  }
}
