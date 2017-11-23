import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/delay';
import 'rxjs/add/operator/map';
 // import {HttpClientModule} from '@angular/common/http';
  import { HttpClient } from '@angular/common/http';

@Injectable()
export class httpServices {
  isLoggedIn = false;

  // store the URL so we can redirect after logging in
  redirectUrl: string;

    // Inject HttpClient into your component or service.
    constructor(private http: HttpClient) {}

getCustomers(): Observable<any> { 
  //   var mike = this.http.get('http://localhost:63131/api/customers/GetCustomers').subscribe(data => {
  //       var mike = this.http.get('http://localhost:52819/api/customers/GetCustomers').subscribe(data => {
  //           console.log(data);
  //     });
  //   var mike = this.http.get('http://localhost:52819/api/customers/GetCustomers');
  //  var mike = this.http.get('http://localhost:52819/api/customers/GetCustomers').map((res: Response) => res.json());
  //   var mike = this.http.get('http://localhost:52819/api/customers/GetCustomers').map(Response.json());
    
  //    .catch((error:any) => Observable.throw(error.json().error || 'Server error')); //...errors if any
  //   var mike = this.http.get('http://localhost:52819/api/customers/GetCustomers').map(res => res.json());

   
   
      return this.http.get('http://localhost:52819/api/customers/GetCustomers');
    }
}




