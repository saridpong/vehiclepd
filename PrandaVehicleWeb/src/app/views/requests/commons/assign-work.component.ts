import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { PlaceNewComponent } from './dialog/place-new.component';
import { PlaceEditComponent } from './dialog/place-edit.component';
import { AssignLineNewComponent } from './dialog/assign-line-new.component';
import { AssignLineEditComponent } from './dialog/assign-line-edit.component';

@Component({
    selector: 'app-assign-work',
    templateUrl: 'assign-work.component.html'
})
export class AssignWorkComponent implements OnInit {

    @Input() requests: any;
    @Input() read: boolean;
    bsModalRef: BsModalRef;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private location: Location,
        private modalService: BsModalService
    ) {
        if (this.requests === undefined || this.requests === null) {
            this.requests = {
                lines: []
            };
        }
    }
    ngOnInit() {

    }

    onSubmit() {

    }
    OnNewRequests() {
        const initialState = {
            criteria: {
                place: {},
                forUse: {},
                quantity: 0,
                amount: 0
            }
        };
        this.bsModalRef = this.modalService.show(AssignLineNewComponent, { initialState });
        this.bsModalRef.content.closeBtnName = 'Close';
        this.bsModalRef.content.onClose.subscribe(result => {
            this.requests.lines.push(result);
        })
    }

    OnEditRequest(data) {
        const initialState = {
            criteria: data
        };
        this.bsModalRef = this.modalService.show(AssignLineEditComponent, { initialState });
        this.bsModalRef.content.closeBtnName = 'Close';
    }


    OnDeleteRequest(data) {
        // this.requests.places.pop()
        this.requests.lines.splice(data, 1);
    }

    onBack() {
        this.location.back();
    }
    removeFunction(myObjects, prop, valu) {
        return myObjects.filter(function (val) {
            return val[prop] !== valu;
        });

    }
}



