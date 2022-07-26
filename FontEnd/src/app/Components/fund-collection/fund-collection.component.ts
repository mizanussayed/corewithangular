import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RestDataService } from 'src/app/Data/restData.service';
import { FundCollection } from 'src/app/Models/fundCollection.model';

@Component({
  selector: 'fund-collection',
  templateUrl: './fund-collection.component.html',
  styleUrls: ['./fund-collection.component.css']
})
export class FundCollectionComponent{

  
  private fundCollectionUrl = `http://${location.hostname}:5000/FundCollection`;
  private fundCollection : FundCollection[];
  public formData = new FundCollection();
  public editting:boolean = false;

  constructor(private dataSource: RestDataService, private toastr: ToastrService, private datePipe: DatePipe) {
    this.refreshData();
  }

  private refreshData(): void {
    this.dataSource.getAll<FundCollection>(this.fundCollectionUrl).subscribe(data => this.fundCollection = data)
  }

  getData(): FundCollection[] {
    return this.fundCollection;
  }
  
  public updateClick(entry:any){
    Object.assign(this.formData, entry );
    this.editting = true;
  }
  public deleteClick(id: number) {
    this.dataSource.deleteEntry(id, this.fundCollectionUrl).subscribe(next => {
      this.toastr.success("fundCollection data  deleted successfully ", "Data Deleted"),
      this.refreshData(),
      this.editting=false;
    });
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
      this.dataSource.saveEntry(this.formData, this.fundCollectionUrl).subscribe(res => {
        this.toastr.success("fundCollection data  added successfully ", "Data added"),
        this.refreshData(),
        this.reset();
      });
    }
  }


  private updateData(form: NgForm) {
    if (form.valid) {
      this.dataSource.updateEntry(this.formData, this.fundCollectionUrl).subscribe(res => {
        this.toastr.success("fundCollection data  updated successfully ", "Data updated"),
        this.refreshData(),
        this.reset();
      });
    }
  }

  private reset() {
    this.formData = new FundCollection();
  }


}
