import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RestDataService } from 'src/app/Data/restData.service';
import { Member } from 'src/app/Models/member.model';

@Component({
  selector: 'memberform',
  templateUrl: './memberform.component.html',
  styleUrls: ['./membertable.component.css']
})


export class MemberFormComponent {
  private memberUrl = `http://${location.hostname}:5000/member`;
  //private memberUrl = `https://localhost:44369/member`;
  public bGroup: string[] = new Array<string>("A+", "A-", "B+", "B-", "O+", "O-", "Ab+", "Ab-")
  private Editable: string = null;
  public edditing: boolean = false;
  public formData = new Member();

  constructor(private dataSource: RestDataService,private router:Router) {
    this.Editable = location.pathname.split("/")[2];
    this.checkEdit();
  }


  private checkEdit(): void {
    if (this.Editable != null) {
      this.dataSource.SingleData<Member>(Number(this.Editable), this.memberUrl).subscribe(res => this.formData = res);
    }
  }

  onSubmit(form: NgForm) {
    if (this.Editable != null) {
      this.updateData(form)
    } else {
      this.insertData(form)
    }
  }

  private insertData(form: NgForm) {
    if (form.valid) {
      this.dataSource.saveEntry(this.formData, this.memberUrl).subscribe(res => {
        
        this.router.navigateByUrl("/");
      });
    }
  }


  private updateData(form: NgForm) {
    if (form.valid) {
      this.dataSource.updateEntry(this.formData, this.memberUrl).subscribe(res => {
        this.reset();
        
      });
    }
  }

  private reset() {
    this.formData = new Member();
  }

  // public imageUrl= "/assets/R.jpg";
  // public iconUrl:string = "/assets/photo.png";

  public handleFile(event:any){
    if(event.target.files && event.target.files[0])
    var reader = new FileReader();
    reader.onload = (event:any)=>{
        this.formData.picture =  event.target.result;
    }
    reader.readAsDataURL(event.target.files[0]); 
  }



}
