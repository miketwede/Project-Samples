import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';  
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, RouterModule, Routes } from '@angular/router';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {

  subscription = "";
  email = "";
  password = "";


  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute) { 
    console.log("this.route.paramMap = ", this.route.paramMap);

  }

  //constructor(private route: ActivatedRoute) {} 

  // constructor(Subscription: string, Email: string, Password: string) { 
    // this.subscription = 'Subscription';
    // this.email = 'Email';
    // this.password = 'Password';

  // }

  ngOnInit() {

    // this.route.paramMap.pipe(
    //   switchMap((params: ParamMap) => {
    //     // (+) before `params.get()` turns the string into a number
    //     this.subscription = params.get('subscription');
    //     this.email = params.get('email');
    //     this.password = params.get('password');
    //   })
    // );

    var routeParams;

    this.route.params.subscribe(params => 
      // use params now as a object variable

               routeParams = params

        // this.email = params.get('email');
        // this.password = params.get('password');
  );

  this.subscription = routeParams.subscription;
  this.email = routeParams.email;
  this.password = routeParams.password;


// resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> {
//   return route.params.switchMap(params => this.FixturesService.getFixtures(params));
// }

    // console.log("this.route.paramMap = ", this.route.paramMap);
    // console.log("route = ", this.route);
    // console.log("params = ", this.route.params);
  }

  
}
