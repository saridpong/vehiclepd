import { CoursesService } from '../../services/courses.services';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'dashboard.component.html'
})
export class DashboardComponent implements OnInit {

  public mCourse: any = { courseItems: [] }
  constructor(private courses: CoursesService, private route: Router) {
    if (window.localStorage.getItem('token') !== null) {
      this.courses.find({ courseItems: { courseID: 0, companyID: 0, courseName: '', useFlag: 1, startDate: '', endDate: '' } }).subscribe(result => {
        this.mCourse = result;
      });
    } else {
      this.route.navigate(['pages/login']);
    }
  }
  ngOnInit() {

  }
}
