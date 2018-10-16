import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';
import { AuthService } from '../../services/auth.services';
import { AssignService } from 'app/services/assign.services';



@Component({
  templateUrl: 'assign-search.component.html'
})
export class AssignSearchComponent implements OnInit {

  public criteria: any;
  mSearch: any;
  mStatus = status;
  mRole: any = 'REQUEST';
  mView: any;
  constructor(
    private route: Router,
    private auth: AuthService,
    private assign: AssignService,
    private viewRef: ViewContainerRef) {
    this.criteria = {
      status: -1
    };
    this.mSearch = {};
    this.onSearch();
    this.mRole = auth.getRole();
    if (this.mRole === 'ADMIN') {
      this.mView = {
        approve: true,
      }
    } else if (this.mRole === 'REQUEST') {
      this.mView = {
        approve: false,
      }
    }
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
  onView(item) {
    if (item.status === 1) {
      this.route.navigate(['requests/assign/view/' + item.assignHeaderID]);
    } else if (item.status === 2 || item.status === 3) {
      this.route.navigate(['requests/assign/approve/view/' + item.assignHeaderID]);
    }
  }
  onEdit(item) {
    this.route.navigate(['requests/assign/update/' + item.assignHeaderID]);
  }
  onApprove(item) {
    this.route.navigate(['requests/assign/approve/' + item.assignHeaderID]);
  }
  onSearch() {
    this.assign.find(this.criteria).subscribe(result => {
      this.mSearch = result;
    });
  }
}

const status = [
  {
    text: 'ทั้งหมด',
    value: -1
  },
  {
    text: 'รออนุมัติ',
    value: 1
  },
  {
    text: 'อนุมัติ',
    value: 2
  },
  {
    text: 'ยกเลิก',
    value: 3
  }
]
