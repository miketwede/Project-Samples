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
  customerID: number,
  accountNumber: string,
  emailPromotion: string,
  person: {
    personID: number,
    title: string,
    firstName: string,
    lastName: string,
    middleInitial: string,
    suffix: string,
    addressID: number,
    address1: string,
    address2: string,
    city: string,
    state: string,
    zip: string,
    country: string,
    emailAddressID: number,
    emailAddress: string,
    phoneNumberID: number,
    phoneNumber: string,
    photo: string,    
  },
  demographics: {
    totalPurchaseYTD: number,
    dateFirstPurchase: Date,
    birthDate: Date,
    maritalStatus: string,
    yearlyIncome: string,
    gender: string,
    totalChildren: number,
    numberChildrenAtHome: number,
    education: string,
    occupation: string,
    homeOwnerFlag: boolean ,
    numberCarsOwned: number,
    commuteDistance: string,
  },
  additionalContactInfo: any,
  hideDetail: boolean,
}

@Injectable()
  export class CustomerService {

  constructor(private http: httpServices) { 
  }

  getCustomers()  : Observable<any> { 
    return this.http.getCustomers(); 
  }

  getCustomer(id: number | string) {
    return this.http.getCustomer(id); 
    // return this.getCustomers()
    //   .map(customer => customer.find(customer => customer.customerID === +id));
  }

  // addCustomer(accountNumber: string) {
  //   accountNumber = accountNumber.trim();
  //   if (accountNumber) {
  //     let customer = new Customer(CustomerService.nextCustomerId++, accountNumber);
  //     this.customers.push(customer);
  //    // this.customer$.next(this.customers);
  //   }
  // }

  updateCustomer(customer: ICustomer) {
    return this.http.updateCustomer(customer); 
  }

  // deleteCustomer(accountNumber: string) {
  //   accountNumber = accountNumber.trim();
  //   if (accountNumber) {
  //     let customer = new Customer(CustomerService.nextCustomerId++, accountNumber);
  //     this.customers.push(customer);
  //    // this.customer$.next(this.customers);
  //   }
  // }

}
