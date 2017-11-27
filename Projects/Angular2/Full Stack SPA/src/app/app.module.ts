import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { Router } from '@angular/router';

import { AppComponent }            from './app.component';
import { AppRoutingModule }        from './app-routing.module';

import { HeroesModule }            from './heroes/heroes.module';
import { CustomerModule }            from './customers/customer.module';
import { ComposeMessageComponent } from './compose-message.component';
import { LoginRoutingModule }      from './login-routing.module';
import { LoginComponent }          from './login.component';
import { PageNotFoundComponent }   from './not-found.component';

import { DialogService }           from './dialog.service';
import { httpServices }           from '../services/httpServices';
import { Common }                 from '../utilities/Common';

import { HttpClientModule } from '@angular/common/http';
// import { Http, Response, Headers, RequestOptions } from '@angular/http';

// import { CustomerListComponent }    from './customers/customer-list.component';
// import {CustomerDetailGrid} from "./customers/CustomerDetailGrid.component";

// ag-grid
//import { AgGridModule }  from "ag-grid-angular";
//import {AgGridModule} from "ag-grid-angular/main";
// ag-grid
import {AgGridModule} from "ag-grid-angular";

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    CustomerModule,
    HeroesModule,
    LoginRoutingModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    // AgGridModule.withComponents([CustomerListComponent, CustomerDetailGrid])
    //httpServices
  //   HttpClientXsrfModule.withOptions({
  //     cookieName: 'XSRF-TOKEN',
  //     headerName: 'X-XSRF-TOKEN'
  // }),
  ],
  declarations: [
    AppComponent,
    ComposeMessageComponent,
    LoginComponent,
    PageNotFoundComponent
    // httpServices
  ],
  providers: [
    DialogService,
    httpServices,
    Common,
    //Http
    // HttpClient,
    // {
    //     provide: HttpHandler,
    //     useFactory: interceptingHandler,
    //     deps: [HttpBackend, [new Optional(), new Inject(HTTP_INTERCEPTORS)]]
    // },
    // HttpXhrBackend,
    // { provide: HttpBackend, useExisting: HttpXhrBackend },
    // BrowserXhr,
    // { provide: XhrFactory, useExisting: BrowserXhr },
  ],
  bootstrap: [ AppComponent ]
  })
export class AppModule {
  // Diagnostic only: inspect router configuration
  constructor(router: Router) {
    console.log('Routes: ', JSON.stringify(router.config, undefined, 2));
  }
}
