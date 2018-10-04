import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap';
import { Subject } from 'rxjs/Subject';


@Component({
  templateUrl: 'place-edit.component.html'
})
export class PlaceEditComponent implements OnInit {
  public onClose: Subject<any>;
  criteria: any = {};
  constructor(public bsModalRef: BsModalRef) { }
  ngOnInit() {
    this.onClose = new Subject();
  }
  OnSubmit() {
    this.onClose.next(this.criteria);
    this.bsModalRef.hide();
  }
}

