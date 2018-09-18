import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-new-cars',
    templateUrl: 'cars-new.component.html'
})
export class CarsNewComponent implements OnInit {
    roots: any = [];
    mCriteria: any;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private toastr: ToastrService,
        private location: Location
    ) {
        this.mCriteria = [];
    }
    ngOnInit() {

    }

    onSubmit() {

    }

    onBack() {
        this.location.back();
    }
}
