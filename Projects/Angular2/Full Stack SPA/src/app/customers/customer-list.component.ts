import 'rxjs/add/operator/switchMap';
import { Observable }                             from 'rxjs/Observable';
import { Component, OnInit }                      from '@angular/core';
import { ActivatedRoute, ParamMap }               from '@angular/router';
import {DomSanitizer}                             from '@angular/platform-browser';

import { Customer, CustomerService, ICustomer }   from './customer.service';
import { httpServices }                           from '../../services/httpServices';
import { Common }                                 from '../../utilities/Common';

@Component({
  template: `
    <div class="list" *ngFor="let customer of customers$ | async" [class.selected]="customer.customerID === selectedId">

      <div >
        <button class="badge" (click)="customer.hideDetail = !customer.hideDetail"><b>+</b></button>
        
        <a [routerLink]="['/customer', customer.customerID]">
        <span> {{common.formatName(customer.person)}}     </span>
          <span> {{customer.person.phoneNumber}}            </span>
          <span> {{customer.person.emailAddress}}           </span>
          <span> {{customer.accountNumber}}                 </span>
          <span> {{common.formatAddress(customer.person)}}  </span>
        </a>
      </div>

      <div *ngIf="customer.hideDetail" className="full-width-panel">
        <div class="row">
            <div class="col-lg-12">

                <div class="col-lg-3">
                    <div className="full-width-detail">
                    <img width="120px" height="130px" [src]="this.getSafeImgString(customer.person.photo)" alt="Customer Photo" style="border:2px solid gold"/>  
                </div>
                  
                <div className="full-width-detail">
                  {{common.formatName(customer.person)}} 
                </div>
            </div>

                <div class="col-lg-3">
                  <div className="full-width-detail" style="padding:10px">
                    <b>Birth Date:        </b> {{this.common.formatDate(customer.demographics.birthDate.toLocaleString(), this.dateFormat)}} 
                  </div>
                  <div className="full-width-detail" style="padding:10px">
                    <b>Marital Status:    </b> {{customer.demographics.maritalStatus}}  
                  </div>
                  <div className="full-width-detail" style="padding:10px">
                    <b>Total Children:    </b> {{customer.demographics.totalChildren}}  
                  </div>
                  <div className="full-width-detail" style="padding:10px">
                    <b>Children At Home:  </b> {{customer.demographics.numberChildrenAtHome}} 
                  </div>
              </div>

              <div class="col-lg-3">
                  <div className="full-width-detail" style="padding:10px">
                    <b>Gender:      </b> {{customer.demographics.gender}} 
                  </div>
                  <div className="full-width-detail" style="padding:10px">
                    <b>Education:   </b> {{customer.demographics.education}}  
                  </div>
                  <div className="full-width-detail" style="padding:10px">
                    <b>Occupation:  </b> {{customer.demographics.occupation}} 
                  </div>
                  <div className="full-width-detail" style="padding:10px">
                    <b>Owns Home:   </b> {{customer.demographics.homeOwnerFlag.toString()}} 
                  </div>
              </div>

              <div class="col-lg-3">
                  <div className="full-width-detail" style="padding:10px">
                    <b>Number Of Cars Owned:    </b> {{customer.demographics.numberCarsOwned}}  
                  </div>
                  <div className="full-width-detail" style="padding:10px">
                    <b>Commute Distance:        </b> {{customer.demographics.commuteDistance}}  
                  </div>
                  <div className="full-width-detail" style="padding:10px">
                    <b>Yearly Income:           </b> {{this.formatYTD(customer.demographics.yearlyIncome) }}  
                  </div>
                  <div className="full-width-detail" style="padding:10px">
                    <b>Date Of First Purchase:  </b> {{common.formatDate(customer.demographics.dateFirstPurchase.toLocaleString(), this.dateFormat)}} 
                  </div>
                  <div className="full-width-detail" style="padding:10px">
                    <b>Total Purchases YTD:     </b> {{common.formatCurrency(customer.demographics.totalPurchaseYTD)}}  
                  </div>
              </div>
              
            </div>
        </div>
      </div>

    </div>

    <router-outlet></router-outlet>
  `
})
export class CustomerListComponent implements OnInit {
  customers$: Observable<ICustomer>;
  selectedId: number;
  public expanded = false;
  public dateFormat = "mm/dd/yyyy";

  constructor(
    public service: CustomerService,
    public route: ActivatedRoute,
    public common: Common,
    public _DomSanitizer: DomSanitizer
  ) {}

  ngOnInit() {
    this.customers$ = this.service.getCustomers();
    this.service.getCustomers().subscribe(val => console.log(val));
    };

  formatYTD(amount) {
    if (!amount) {
      return null;
      }
    else {
      return this.common.formatCurrency(amount.substring(0, amount.indexOf('-'))) + "-" + this.common.formatCurrency(amount.substring(amount.indexOf('-')+1, amount.length));
      }
  }

  getSafeImgString(image) {
      return this._DomSanitizer.bypassSecurityTrustResourceUrl("data:image/jpeg;base64, " + image);
    }
  }

