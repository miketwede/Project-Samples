import { Component, OnInit, HostBinding } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { slideInDownAnimation }   from '../animations';
import { Customer }         from './customer.service';
import { DialogService }  from '../dialog.service';

@Component({
  template: `
  <div *ngIf="customer">
    <h3>"{{ customer.accountNumber }}"</h3>
    <div>
      <label>Id: </label>{{ customer.customerID }}</div>
    <div>
      <label>Account: </label>
      <input [(ngModel)]="customer.accountNumber" placeholder="account number"/>
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

  customer: Customer;
  accountNumber: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    public dialogService: DialogService
  ) {}

  ngOnInit() {
    this.route.data
      .subscribe((data: { customer: Customer }) => {
        this.accountNumber = data.customer.accountNumber;
        this.customer = data.customer;
      });
  }

  cancel(customer) {
    this.gotoCrises();
  }

  save(customer) {
    this.customer = customer;
    this.gotoCrises();
  }

  canDeactivate(): Observable<boolean> | boolean {
    // Allow synchronous navigation (`true`) if no customer or the customer is unchanged
    if (!this.customer || this.customer.accountNumber === this.accountNumber) {
      return true;
    }
    // Otherwise ask the user with the dialog service and return its
    // observable which resolves to true or false when the user decides
    return this.dialogService.confirm('Discard changes?');
  }

  gotoCrises() {
    let customerId = this.customer ? this.customer.customerID : null;
    // Pass along the customer id if available
    // so that the CustomerListComponent can select that customer.
    // Add a totally useless `foo` parameter for kicks.
    // Relative navigation back to the crises
    // this.router.navigate(['../', { id: customerId, foo: 'foo' }], { relativeTo: this.route });
    this.router.navigate(['/customers', { id: customerId, foo: 'foo' }], { relativeTo: this.route });
    
  }
}
