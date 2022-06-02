import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { MembertableComponent } from './member/membertable.component';
import { PurchageComponent } from './purchage/purchage.component';
import { SessionComponent } from './session/session.component';
import { FundCollectionComponent } from './fund-collection/fund-collection.component';
import {HttpClientModule}  from '@angular/common/http'
import { RestDataService } from '../Data/restData.service';
import { FormsModule } from '@angular/forms';
import { MemberFormComponent } from './member/memberform.component';
import { RouterLink, RouterModule } from '@angular/router';


const comp = [
  MembertableComponent, PurchageComponent, SessionComponent, FundCollectionComponent,MemberFormComponent
];

@NgModule({
  declarations: [
    comp
  ],
  imports: [
    CommonModule, HttpClientModule , FormsModule, RouterModule
  ],
  providers:[
    RestDataService, DatePipe
  ],
  exports:[
    comp
  ]
})
export class ComModuleModule { }
