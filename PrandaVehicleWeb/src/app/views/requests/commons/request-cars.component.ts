import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { PlaceNewComponent } from './dialog/place-new.component';
import { PlaceEditComponent } from './dialog/place-edit.component';

@Component({
    selector: 'app-request-cars',
    templateUrl: 'request-cars.component.html'
})
export class RequestCarsComponent implements OnInit {

    @Input() requests: any;
    @Input() read: boolean;
    bsModalRef: BsModalRef;
    mPriority: any = priorityList;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private location: Location,
        private modalService: BsModalService
    ) {
        if (this.requests === undefined || this.requests === null) {
            this.requests = {
                forUse:{},
                places: [],
                requestFor: {}
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
                place: {}
            }
        };
        this.bsModalRef = this.modalService.show(PlaceNewComponent, { initialState });
        this.bsModalRef.content.closeBtnName = 'Close';
        this.bsModalRef.content.onClose.subscribe(result => {
            this.requests.places.push(result);
        })
    }

    OnEditRequest(data) {
        const initialState = {
            criteria: data
        };
        this.bsModalRef = this.modalService.show(PlaceEditComponent, { initialState });
        this.bsModalRef.content.closeBtnName = 'Close';
    }

    onStartDate() {
        this.requests.endDate = this.requests.startDate;
    }

    OnDeleteRequest(data) {
        // this.requests.places.pop()
        this.requests.places.splice(data, 1);
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

const priorityList = [
    {
      text: 'A',
    },
    {
      text: 'B',
    },
    {
      text: 'C',
    },
    {
      text: 'D',
    },
    {
      text: 'E',
    }
  ]


