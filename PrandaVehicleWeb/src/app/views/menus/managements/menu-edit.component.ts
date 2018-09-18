import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Menu } from '../../../model/menu';
import { MenuService } from '../../../services/menu.services';
import { ToastrService } from 'ngx-toastr';


@Component({
    selector: 'app-edit-menu',
    templateUrl: 'menu-edit.component.html'
})
export class MenuEditComponent implements OnInit {
    _ref: any;
    @Input() _id: any;
    @Output() close: EventEmitter<any> = new EventEmitter();
    @Output() refresh: EventEmitter<any> = new EventEmitter();
    criteria = new Menu(0, '', '', '', 0, true);
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
        this.menu.GetByID(this._id).subscribe(result => {
            this.criteria = new Menu(result.menuSystemID, result.menuIcon, result.menuSystemName, result.menuSystemURL, 0, result.useFlag);
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
        this.menu.UpdateMenu(this.criteria).subscribe(result => {
            if (result.status === 1) {
                this.toastr.success('Update Success.', 'Edit Menu')
                this.onClose();
                this.onRefresh();
            } else {
                this.toastr.error('Update Failed.', 'Edit Menu')
            }
        });
    }
}
