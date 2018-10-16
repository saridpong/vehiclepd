
import { Component, OnInit, ViewChild, ViewContainerRef, ComponentFactoryResolver } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.services';
import { UserService } from '../../../services/user.services';
import { UserManagementComponent } from './user-management.component';



@Component({
  templateUrl: 'user-search.component.html'
})
export class UserSearchComponent implements OnInit {
  public criteria: any;
  mSearch: any;
  mStatus = status;
  mRole: any = 'REQUEST';
  mView: any;
  constructor(
    private route: Router,
    private auth: AuthService,
    private user: UserService,
    private _cfr: ComponentFactoryResolver,
    private viewRef: ViewContainerRef) {
    this.criteria = {
      status: -1
    };
    this.mSearch = {};
    this.onSearch();
    this.mRole = auth.getRole();
    // if (window.localStorage.getItem('token') !== null) {
    //   this.courses.find({ courseItems: { courseID: 0, companyID: 0, courseName: '', useFlag: 1, startDate: '', endDate: '' } }).subscribe(result => {
    //     this.mCourse = result;
    //   });
    // } else {
    //   this.route.navigate(['pages/login']);
    // }
  }
  ngOnInit() {

  }
  onSearch() {
    this.user.find(this.criteria).subscribe(result => {
      this.mSearch = result;
    });
  }
  onNewUser() {
    this.route.navigate(['/setup/user/new']);
  }
  onEditUser(item) {
    this.route.navigate(['/setup/user/edit/' + item.userID]);
  }
}

const status = [
  {
    text: 'ทั้งหมด',
    value: -1
  },
  {
    text: 'ใช้งาน',
    value: 1
  },
  {
    text: 'ไม่ใช้งาน',
    value: 2
  }
]
