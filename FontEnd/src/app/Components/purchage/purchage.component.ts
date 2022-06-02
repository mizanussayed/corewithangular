import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RestDataService } from 'src/app/Data/restData.service';
import { Purchage } from 'src/app/Models/purchage.model';
import { Session } from 'src/app/Models/session.model';

@Component({
  selector: 'purchage',
  templateUrl: './purchage.component.html',
  styleUrls: ['./purchage.component.css']
})
export class PurchageComponent {

  private purchageUrl = `http://${location.hostname}:5000/purchage`;
  private purchage: Purchage[];

  private sessionUrl = `http://${location.hostname}:5000/session`;
  private session: Session[];
  public formData = new Purchage();
  public editting:boolean = false;

  constructor(private dataSource: RestDataService, private toastr: ToastrService, private datePipe: DatePipe) {
    this.refreshData();
  }

  private refreshData(): void {
    this.dataSource.getAll<Purchage>(this.purchageUrl).subscribe(data => this.purchage = data);
    this.dataSource.getAll<Session>(this.sessionUrl).subscribe(data => this.session = data);
  }

  get SessionData(): Session[]{
    return this.session;
  }
  getData(): Purchage[] {
    return this.purchage;
  }
  
  public updateClick(entry:any){
    Object.assign(this.formData, entry );
    this.editting = true;
  }
  public deleteClick(id: number) {
    this.dataSource.deleteEntry(id, this.purchageUrl).subscribe(res => {
      this.toastr.warning("purchage data  deleted successfully ", "Data Deleted"),
      this.refreshData(),
      this.editting=false;
    });
  }

  public setSession(v:any){
    this.formData.sessionNumber = Number(v);
    console.log(Number(v));
    
  }
  onSubmit(form: NgForm) {
    if (this.editting) {
      this.updateData(form)
    } else {
      this.insertData(form)
    }
  }

  private insertData(form: NgForm) {
    if (form.valid) {
      this.dataSource.saveEntry(this.formData, this.purchageUrl).subscribe(res => {
        this.toastr.success("purchage data  added successfully ", "Data added"),
        this.refreshData(),
        this.reset();
      });
    }
  }


  private updateData(form: NgForm) {
   
    if (form.valid) {
      this.dataSource.updateEntry(this.formData, this.purchageUrl).subscribe(res => {
        this.toastr.success("purchage data  updated successfully ", "Data updated"),
        this.refreshData(),
        this.reset();
      });
    }
  }

  private reset() {
    this.formData = new Purchage();
  }


}
