import { CoursesService } from '../../services/courses.services';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';



@Component({
  templateUrl: 'assign.component.html'
})
export class AssignComponent implements OnInit {

  public mCourse: any = { courseItems: [] }
  constructor(
    private courses: CoursesService,
    private route: Router,
    private router: Router) {
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
  onpay() {
    this.router.navigate(['assign/pay']);
  }
}
