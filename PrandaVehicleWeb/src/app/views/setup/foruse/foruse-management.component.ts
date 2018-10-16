import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ForUseService } from '../../../services/foruse.services';

@Component({
    templateUrl: 'foruse-management.component.html'
})
export class ForUseManagementComponent implements OnInit {
    public criteria: any;
    public formtitle: string;
    public read: boolean = false;
    constructor(
        private toastr: ToastrService,
        private route: Router,
        private router: ActivatedRoute,
        private foruse: ForUseService) {
        const role = this.router.snapshot.data['role'];
        const formtitle = this.router.snapshot.data['title'];

        this.formtitle = formtitle;
        if (role === undefined) {
            this.criteria = {
                status: 1
            };
        } else if (role === 'view') {
            this.read = true;
            this.bindData();

        } else if (role === 'update') {
            this.read = false;
            this.bindData();
        }
    }

    bindData() {
        const id = this.router.snapshot.paramMap.get('id');
        const findbyid = {
            foruseID: id
        }
        this.foruse.findbyid(findbyid).subscribe(result => {
            if (result.forUseData === undefined || result.forUseData === null) {
                result.forUseData = {};
            }
            this.criteria = result.forUseData;
            this.criteria.status === 2 ? this.criteria.status = false : this.criteria.status = true;
        });
    }
    ngOnInit() {

    }
    onSubmit() {
        const role = this.router.snapshot.data['role'];
        if (role === undefined) {
            this.criteria.status = 1;
            this.foruse.newForUse(this.criteria).subscribe(result => {
                if (result.responseStatus === 1) {
                    this.toastr.success('Create Success.', result.description)
                    this.route.navigate(['/setup/foruse/search']);
                } else {
                    this.toastr.error('Create Failed.', result.description)
                }
            });
        } else if (role === 'update') {
            this.criteria.status === false ? this.criteria.status = 2 : this.criteria.status = 1;
            this.foruse.updateForUse(this.criteria).subscribe(result => {
                if (result.responseStatus === 1) {
                    this.toastr.success('Update Success.', result.description);
                    this.route.navigate(['/setup/foruse/search']);
                } else {
                    this.toastr.error('Update Failed.', result.description);
                }
            });
        }
    }
    onBack() {
        this.route.navigate(['/setup/foruse/search']);
    }

}
