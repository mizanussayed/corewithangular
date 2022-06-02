import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { ComModuleModule } from './Components/comModule.module';
import { ToastrModule } from 'ngx-toastr';
import {BrowserAnimationsModule } from '@angular/platform-browser/animations';





@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, CommonModule, ComModuleModule, ToastrModule.forRoot(), BrowserAnimationsModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
