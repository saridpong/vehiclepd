import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
    selector: 'app-approve-cars',
    templateUrl: 'approve-cars.component.html'
})
export class ApproveCarsComponent implements OnInit {

    @Input() requestApprove: any;
    @Input() read: boolean;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private location: Location
    ) {
        if (this.requestApprove === undefined || this.requestApprove === null) {
            this.requestApprove = {
                driver: {},
                vehicle: {}
            };
        }
    }
    ngOnInit() {

    }

    onSubmit() {

    }

    onBack() {
        this.location.back();
    }
}
