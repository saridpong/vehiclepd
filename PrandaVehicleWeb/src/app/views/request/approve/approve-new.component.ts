import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-new-approve',
    templateUrl: 'approve-new.component.html'
})
export class ApproveNewComponent implements OnInit {
    mConfig: any = {
        height: '150px'
    };
    roots: any = [];
    mCriteria: any;
    @Output() close: EventEmitter<any> = new EventEmitter();
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
    onClose() {
        this.close.emit();
    }
}
