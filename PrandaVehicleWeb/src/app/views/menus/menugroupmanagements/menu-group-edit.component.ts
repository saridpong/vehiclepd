import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Menu } from '../../../model/menu';
import { MenuService } from '../../../services/menu.services';
import { ToastrService } from 'ngx-toastr';
import { Role } from '../../../model/role';


@Component({
    selector: 'app-edit-group',
    templateUrl: 'menu-group-edit.component.html'
})
export class MenuEditGroupComponent implements OnInit {
    _ref: any;
    @Input() _id: any;
    @Output() close: EventEmitter<any> = new EventEmitter();
    @Output() refresh: EventEmitter<any> = new EventEmitter();
    criteria = new Role(0, '', true);
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private menu: MenuService,
        private toastr: ToastrService
    ) {

    }
    ngOnInit() {

    }
    onBinding() {
        this.menu.GetRoleByID(this._id).subscribe(result => {
            this.criteria = new Role(result.menuSystemGroupID, result.menuSystemGroupName, result.useFlag);
        });
    }
    onClose() {
        this.close.emit();
    }
    onRefresh() {
        this.refresh.emit();
    }
    removeObject() {
        this._ref.destroy();
    }
    onSubmit() {
        this.menu.UpdateRole(this.criteria).subscribe(result => {
            if (result.status === 1) {
                this.toastr.success('Update Success.', 'Edit Role')
                this.onClose();
                this.onRefresh();
            } else {
                this.toastr.error('Update Failed.', 'Edit Role')
            }
        });
    }
}
