import { LocationService } from './../../../services/location.services';
import { DriverService } from './../../../services/driver.services';
import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { PlaceNewComponent } from './dialog/place-new.component';
import { PlaceEditComponent } from './dialog/place-edit.component';
import { AssignLineNewComponent } from './dialog/assign-line-new.component';
import { AssignLineEditComponent } from './dialog/assign-line-edit.component';

@Component({
    selector: 'app-assign-approve-part',
    templateUrl: 'assign-approve-part.component.html'
})
export class AssignApprovePartComponent implements OnInit {

    @Input() requests: any;
    @Input() read: boolean;
    bsModalRef: BsModalRef;
    mDriver: any;
    mLocation: any;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private location: Location,
        private modalService: BsModalService,
        private driverm: DriverService,
        private locationm: LocationService
    ) {
        if (this.requests === undefined || this.requests === null) {
            this.requests = {
                lines: []
            };
        }
        const criteriaDriver = { status: 1 };
        this.driverm.find(criteriaDriver).subscribe(result => {
            this.mDriver = result;
        })

        const criteriaLocation = { status: 1 };
        this.locationm.find(criteriaLocation).subscribe(result => {
            this.mLocation = result;
        })
    }
    ngOnInit() {

    }

    onSubmit() {

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



