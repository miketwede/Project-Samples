import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/delay';
import 'rxjs/add/operator/map';
 // import {HttpClientModule} from '@angular/common/http';
  import { HttpClient, HttpHeaders  } from '@angular/common/http';
  // import { Http, Response, Headers, RequestOptions } from '@angular/http';

  import { ICustomer } from '../app/customers/customer.service';

@Injectable()
export class httpServices {
  isLoggedIn = false;
  public headers: Headers;

  // store the URL so we can redirect after logging in
  redirectUrl: string;

    // Inject HttpClient into your component or service.
    constructor(private http: HttpClient) {
      this.http = http;
      this.headers = new Headers();
      this.headers.append('Content-Type', 'application/json');
    }
    // constructor(private http: Http) {}
    
    GetCustomerByCustomerID
    
    getCustomer(customerID): Observable<ICustomer> { 
      
    // Setup log namespace query parameter
    let params = new URLSearchParams();
    params.set('params', customerID);

          return this.http.get<ICustomer>("http://localhost:52819/api/customers/GetCustomerByCustomerID/", {
            params: {
              customerID: customerID
            }
            });

        }   

    getCustomers(): Observable<ICustomer> { 
      //   var mike = this.http.get('http://localhost:63131/api/customers/GetCustomers').subscribe(data => {
      //       var mike = this.http.get('http://localhost:52819/api/customers/GetCustomers').subscribe(data => {
      //           console.log(data);
      //     });
      //   var mike = this.http.get('http://localhost:52819/api/customers/GetCustomers');
      //  var mike = this.http.get('http://localhost:52819/api/customers/GetCustomers').map((res: Response) => res.json());
      //   var mike = this.http.get('http://localhost:52819/api/customers/GetCustomers').map(Response.json());
        
      //    .catch((error:any) => Observable.throw(error.json().error || 'Server error')); //...errors if any
      //   var mike = this.http.get('http://localhost:52819/api/customers/GetCustomers').map(res => res.json());
    
        
        
          return this.http.get<ICustomer>('http://localhost:52819/api/customers/GetCustomers');
        }

updateCustomer(customer: ICustomer) { 
          let httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
          };
          /////////////let headers = new Headers({ 'Content-Type': 'application/json' });
          // let options = new RequestOptions({ headers: headers });
let options = { headers: this.headers };



let headers = new Headers();
//this.createAuthorizationHeader(headers);

let url = 'http://localhost:52819/api/customers/UpdateCustomer';
let body = JSON.stringify({customer:customer});            

// const req =  this.http.post(url, customer)
// .subscribe(
//   res => {
//     console.log("response: ", res);
//   },
//   err => {
//     console.log("error: ",err);
//   }
// )


return this.http.post(url, customer);

}

// return this.http.post(url, body, { headers: headers })
// return this.http.post(url, body, httpOptions)
// .map(this.extractData)
          // .catch(this.handleError);

              // return this.http.post(url, customer);
    
            
    

            private extractData(res: Response) {
              let body = res.json();
           //   return body.data || {};
          }
      
          private handleError(error: Response) {
              console.error(error);
          //    return Observable.throw(error.json().error || 'Server Error');
          }
          
          

}




