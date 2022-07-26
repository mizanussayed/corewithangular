import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FundCollectionComponent } from './Components/fund-collection/fund-collection.component';
import { MemberFormComponent } from './Components/member/memberform.component';
import { MembertableComponent } from './Components/member/membertable.component';
import { PurchageComponent } from './Components/purchage/purchage.component';
import { SessionComponent } from './Components/session/session.component';


const routes: Routes = [
  {path: "", component: MembertableComponent},
  {path: "create", component: MemberFormComponent},
  {path: "edit/:cardNumber", component:MemberFormComponent},
  {path:"session" , component:SessionComponent},
  {path: "purchase", component:PurchageComponent},
  {path: "fundcollect", component: FundCollectionComponent},
  {path:"**", component:MembertableComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
