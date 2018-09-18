import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-new-document',
    templateUrl: 'document-new.component.html'
})
export class CarsDocumentNewComponent implements OnInit {
    mConfig: any = {
        height: '150px'
    };
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
