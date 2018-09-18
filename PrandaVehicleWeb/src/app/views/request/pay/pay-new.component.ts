import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
// import { ToastrService } from 'ngx-toastr';
import { Location } from '@angular/common';

@Component({
    selector: 'app-new-pay',
    templateUrl: 'pay-new.component.html'
})
export class PayNewComponent implements OnInit {
    roots: any = [];
    mCriteria: any;
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        // private toastr: ToastrService,
        private location: Location
    ) {
        this.mCriteria = [];
    }
    ngOnInit() {

    }

    onSubmit(name: string) {

    }

    onBack() {
        this.location.back();
    }
}
