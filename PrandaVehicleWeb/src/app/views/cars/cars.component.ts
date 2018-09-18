import { CoursesService } from '../../services/courses.services';
import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';



@Component({
  templateUrl: 'cars.component.html'
})
export class CarsComponent implements OnInit {

  public mCourse: any = { courseItems: [] }
  constructor(
    private courses: CoursesService,
    private route: Router,
    private router: Router,
    private modalService: ModalDialogService,
    private viewRef: ViewContainerRef) {
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
  onView() {
    this.router.navigate(['cars/newcars']);
  }
  onNewDocument() {
    this.router.navigate(['cars/newdocumentcars']);
  }
}
