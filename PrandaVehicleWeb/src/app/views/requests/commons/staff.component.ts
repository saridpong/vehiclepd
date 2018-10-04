import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
    selector: 'app-staff',
    templateUrl: 'staff.component.html'
})
export class StaffComponent implements OnInit {

    @Input() staff: any;
    @Input() read: boolean;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private location: Location
    ) {
        if (this.staff === undefined || this.staff === null) {
            this.staff = {};
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
