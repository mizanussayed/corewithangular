import { Component, Inject, InjectionToken } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RestDataService } from 'src/app/Data/restData.service';
import { Member } from 'src/app/Models/member.model';

@Component({
  selector: 'membertable',
  templateUrl: './membertable.component.html',
  styleUrls: ['./membertable.component.css']
})

export class MembertableComponent {
  private memberUrl = `http://${location.hostname}:5000/member`;
  //private memberUrl = `https://localhost:44369/member`;
  private member: Member[];

  constructor(private dataSource: RestDataService, private toastr: ToastrService) {
    this.refreshData();
  }

  getMembers(): Member[] {
    return this.member;
  }

  private refreshData(): void {
    this.dataSource.getAll<Member>(this.memberUrl).subscribe(data => this.member = data)
  }

  public deleteMember(id: number) {
    this.dataSource.deleteEntry(id, this.memberUrl).subscribe(res => {
      this.toastr.success("Member data  deleted successfully ", "Data Deleted"),
      this.refreshData()
    });
  }
}
