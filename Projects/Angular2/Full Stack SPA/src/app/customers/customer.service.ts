import 'rxjs/add/observable/of';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { httpServices }           from '../../services/httpServices';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';

export class Customer {
  constructor(public customerID: number, public accountNumber: string) { }
}

export interface ICustomer {
  customerID: number;
  accountNumber: string;
  emailPromotion: string;
  person: {
    personID: number;
    title: string;
    firstName: string;
    lastName: string;
    middleInitial: string;
    suffix: string;
    address1: string;
    address2: string;
    city: string;
    state: string;
    zip: string;
    country: string;
    emailAddress: string;
    phoneNumber: string;
    photo: string;    
  };
  demographics: {
    totalPurchaseYTD: number;
    dateFirstPurchase: Date;
    birthDate: Date;
    maritalStatus: string;
    yearlyIncome: string;
    gender: string;
    totalChildren: number;
    numberChildrenAtHome: number;
    education: string;
    occupation: string;
    homeOwnerFlag: boolean ;
    numberCarsOwned: number;
    commuteDistance: string;
  };
  additionalContactInfo: any;
}

@Injectable()
  export class CustomerService {

  constructor(private http: httpServices) { 
  }

  getCustomers()  : Observable<any> { 
    return this.http.getCustomers(); 
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

  // updateCustomer(accountNumber: string) {
  //   accountNumber = accountNumber.trim();
  //   if (accountNumber) {
  //     let customer = new Customer(CustomerService.nextCustomerId++, accountNumber);
  //     this.customers.push(customer);
  //    // this.customer$.next(this.customers);
  //   }
  // }

  // deleteCustomer(accountNumber: string) {
  //   accountNumber = accountNumber.trim();
  //   if (accountNumber) {
  //     let customer = new Customer(CustomerService.nextCustomerId++, accountNumber);
  //     this.customers.push(customer);
  //    // this.customer$.next(this.customers);
  //   }
  // }

}
