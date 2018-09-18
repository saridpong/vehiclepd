import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { CoursesService } from '../../../services/courses.services';



@Component({
  templateUrl: 'assign-approve.component.html'
})
export class AssignApproveComponent implements OnInit {

  public mCourse: any = { courseItems: [] }
  constructor(private courses: CoursesService, private route: Router) {
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
}
