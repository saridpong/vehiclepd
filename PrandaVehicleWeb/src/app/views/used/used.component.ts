import { CoursesService } from '../../services/courses.services';
import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ModalDialogService } from 'ngx-modal-dialog';
import { UsedNewComponent } from './manage/used-new.component';



@Component({
  templateUrl: 'used.component.html'
})
export class UsedComponent implements OnInit {

  public mCourse: any = { courseItems: [] }
  constructor(
    private courses: CoursesService,
    private route: Router,
    private router: Router,
    private modalService: ModalDialogService,
    private viewRef: ViewContainerRef) {

  }
  ngOnInit() {

  }
  onView() {
    this.router.navigate(['used/viewused']);

  }
  onStampTime() {
    this.modalService.openDialog(this.viewRef, {
      title: 'ข้อมูลใบขอใช้รถยนต์',
      childComponent: UsedNewComponent
    });
    // this.router.navigate(['used/addused']);
  }
}
