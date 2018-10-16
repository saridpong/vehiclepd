import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../../services/user.services';

@Component({
    templateUrl: 'user-management.component.html'
})
export class UserManagementComponent implements OnInit {
    mPermission = permission;
    mTitle = title;
    public criteria: any;
    public formtitle: string;
    public read: boolean = false;
    constructor(
        private toastr: ToastrService,
        private route: Router,
        private router: ActivatedRoute,
        private user: UserService) {
        const role = this.router.snapshot.data['role'];
        const formtitle = this.router.snapshot.data['title'];

        this.formtitle = formtitle;
        if (role === undefined) {
            this.criteria = {
                status: 1,
                roleID: 2,
                userTitle: 'นาย'
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
            userID: id
        }
        this.user.findbyid(findbyid).subscribe(result => {
            if (result.userDatas === undefined || result.userDatas === null) {
                result.userDatas = {};
            }
            this.criteria = result.userDatas;
            this.criteria.status === 2 ? this.criteria.status = false : this.criteria.status = true;
        });
    }
    ngOnInit() {

    }
    onSubmit() {
        const role = this.router.snapshot.data['role'];
        if (role === undefined) {
            this.criteria.status = 1;
            this.user.newUser(this.criteria).subscribe(result => {
                if (result.responseStatus === 1) {
                    this.toastr.success('Create Success.', result.description)
                    this.route.navigate(['/setup/user/search']);
                } else {
                    this.toastr.error('Create Failed.', result.description)
                }
            });
        } else if (role === 'update') {
            this.criteria.status === false ? this.criteria.status = 2 : this.criteria.status = 1;
            this.user.updateUser(this.criteria).subscribe(result => {
                if (result.responseStatus === 1) {
                    this.toastr.success('Update Success.', result.description);
                    this.route.navigate(['/setup/user/search']);
                } else {
                    this.toastr.error('Update Failed.', result.description);
                }
            });
        }
    }
    onBack() {
        this.route.navigate(['/setup/user/search']);
    }

}
const permission = [
    {
        text: 'ADMIN',
        value: 1
    },
    {
        text: 'REQUEST',
        value: 2
    },
    {
        text: 'SECURITY',
        value: 3
    }
]
const title = [
    {
        text: 'นาย',
        value: 'นาย'
    },
    {
        text: 'นาง',
        value: 'นาง'
    },
    {
        text: 'นางสาว',
        value: 'นางสาว'
    }
]
