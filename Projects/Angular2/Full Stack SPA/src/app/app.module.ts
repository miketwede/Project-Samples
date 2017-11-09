import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { Router } from '@angular/router';

import { AppComponent }            from './app.component';
import { AppRoutingModule }        from './app-routing.module';

import { HeroesModule }            from './heroes/heroes.module';
import { ComposeMessageComponent } from './compose-message.component';
import { LoginRoutingModule }      from './login-routing.module';
import { LoginComponent }          from './login.component';
import { PageNotFoundComponent }   from './not-found.component';

import { DialogService }           from './dialog.service';
import { httpServices }           from '../services/httpServices';

import { Http, Response } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    HeroesModule,
    LoginRoutingModule,
    AppRoutingModule,
    BrowserAnimationsModule,
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
    PageNotFoundComponent,
    // httpServices
  ],
  providers: [
    DialogService,
    httpServices
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
