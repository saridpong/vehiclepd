import { Component, OnInit, ViewChild, ViewContainerRef, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { CoursesService } from '../../../services/courses.services';
import { ModalDialogService } from 'ngx-modal-dialog';
import { ApproveNewComponent } from './approve-new.component';



@Component({
  templateUrl: 'approve-view.component.html'
})
export class RequestApproveComponent implements OnInit {

  public mCourse: any = { courseItems: [] }
  @Output() close: EventEmitter<any> = new EventEmitter();
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
  onNewApprove() {
    this.modalService.openDialog(this.viewRef, {
      title: 'ข้อมูลใบขอใช้รถยนต์',
      childComponent: ApproveNewComponent
    });
  }
  onView() {
    this.router.navigate(['request/viewrequest']);
  }
  onClose() {
    this.close.emit();
}
}
