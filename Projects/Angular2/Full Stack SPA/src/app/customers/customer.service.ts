import 'rxjs/add/observable/of';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { httpServices }           from '../../services/httpServices';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';

export class Customer {
  constructor(public customerID: number, public accountNumber: string) { }
}

// const CUSTOMER = [
//   new Customer(1, 'customer 1'),
//   new Customer(2, 'customer 2'),
//   new Customer(3, 'customer 3'),
//   new Customer(4, 'customer 4'),
// ];




@Injectable()
// export class CustomerService  implements OnInit{
  export class CustomerService {
    
  static nextCustomerId = 100;
  // private customer$: BehaviorSubject<Customer[]>;
  //public Observable<customers> = [];
  public customers$: Observable<any>;
 //  Observable<customers> = [];




  constructor(private http: httpServices) { 

    // <button (click)="getClients()">getClients</button>
  }


//   ngOnInit() {
//     this.activities$ = this.activityService.getActivities();
// }

  getCustomers()  : Observable<any> { 

    // this.customers = this.http.getCustomers();
    
    // this.customer$ = new BehaviorSubject<Customer[]>(this.customers);

    
    // this.customer$ = new BehaviorSubject<Customer[]>(this.http.getCustomers());


    // return this.customer$; 
  


    this.customers$ = this.http.getCustomers();
    
    
        return this.customers$; 

        


  }

  getCustomer(id: number | string) {
    return this.getCustomers()
      .map(customer => customer.find(customer => customer.customerID === +id));
  }

  // addCustomer(accountNumber: string) {
  //   accountNumber = accountNumber.trim();
  //   if (accountNumber) {
  //     let customer = new Customer(CustomerService.nextCustomerId++, accountNumber);
  //     this.customers.push(customer);
  //    // this.customer$.next(this.customers);
  //   }
  // }
}
