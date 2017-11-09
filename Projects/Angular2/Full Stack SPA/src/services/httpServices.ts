 import { Injectable } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/delay';

// @Injectable()


 // import {HttpClientModule} from '@angular/common/http';
  import { HttpClient } from '@angular/common/http';
@Injectable()
export class httpServices {
  isLoggedIn = false;

  // store the URL so we can redirect after logging in
  redirectUrl: string;

    // Inject HttpClient into your component or service.
    constructor(private http: HttpClient) {}

//   login(): Observable<boolean> {
//     return Observable.of(true).delay(1000).do(val => this.isLoggedIn = true);
//   }

//   logout(): void {
//     this.isLoggedIn = false;
//   }

getCustomers(){ 
    // var mike = this.http.get('http://localhost:63131/api/customers/GetCustomers').subscribe(data => {
        var mike = this.http.get('http://localhost:52819/api/customers/GetCustomers').subscribe(data => {
            console.log(data);
      });

      return mike;
    }
}




