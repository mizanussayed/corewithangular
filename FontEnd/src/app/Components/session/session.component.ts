import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RestDataService } from 'src/app/Data/restData.service';
import { Session } from 'src/app/Models/session.model';

@Component({
  selector: 'session',
  templateUrl: './session.component.html',
  styleUrls: ['./session.component.css']
})

export class SessionComponent {
  private sessionUrl = `http://${location.hostname}:5000/session`;
  private session: Session[];
  public formData = new Session();
  public editting:boolean = false;

  constructor(private dataSource: RestDataService, private toastr: ToastrService) {
    this.refreshData();
  }

  private refreshData(): void {
    this.dataSource.getAll<Session>(this.sessionUrl).subscribe(data => this.session = data)
  }

  getData(): Session[] {
    return this.session;
  }
  
  public updateClick(entry:any){
    Object.assign(this.formData, entry);
    this.editting = true;
  }
  public deleteClick(id: number) {
    this.dataSource.deleteEntry(id, this.sessionUrl).subscribe(res => {
      this.toastr.success("Session data  deleted successfully ", "Data Deleted"),
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
      this.dataSource.saveEntry(this.formData, this.sessionUrl).subscribe(res => {
        this.toastr.success("Session data  added successfully ", "Data added"),
        this.refreshData(),
        this.reset();
      });
    }
  }


  private updateData(form: NgForm) {
    if (form.valid) {
      this.dataSource.updateEntry(this.formData, this.sessionUrl).subscribe(res => {
        this.refreshData(),
        this.reset();
      });
    }
  }

  private reset() {
    this.formData = new Session();
  }


}
