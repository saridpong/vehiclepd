import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Menu } from '../../../model/menu';
import { MenuService } from '../../../services/menu.services';
import { ToastrService } from 'ngx-toastr';
import { Role } from '../../../model/role';

@Component({
    selector: 'app-new-group',
    templateUrl: 'menu-group-new.component.html'
})
export class MenuNewGroupComponent implements OnInit {
    _ref: any;
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
        this.menu.NewRoles(this.criteria).subscribe(result => {
            if (result.status === 1) {
                this.toastr.success('Create Success.', 'New Role')
                this.onClose();
                this.onRefresh();
            } else {
                this.toastr.error('Create Failed.', 'New Rloe')
            }
        });
    }
}
