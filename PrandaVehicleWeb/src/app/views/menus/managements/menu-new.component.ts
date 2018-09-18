import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Menu } from '../../../model/menu';
import { MenuService } from '../../../services/menu.services';
import { ToastrService } from 'ngx-toastr';


@Component({
    selector: 'app-new-menu',
    templateUrl: 'menu-new.component.html'
})
export class MenuNewComponent implements OnInit {
    _ref: any;
    @Output() close: EventEmitter<any> = new EventEmitter();
    @Output() refresh: EventEmitter<any> = new EventEmitter();
    roots: any = [];
    criteria = new Menu(0, '', '', '', 0, true);
    constructor(
        private route: Router,
        private routeActive: ActivatedRoute,
        private menu: MenuService,
        private toastr: ToastrService
    ) {
        this.menu.GetRoots().subscribe(result => {
            this.roots = result;
        });
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
        this.menu.NewMenu(this.criteria).subscribe(result => {
            if (result.status === 1) {
                this.toastr.success('Create Success.', 'New Menu')
                this.onClose();
                this.onRefresh();
            } else {
                this.toastr.error('Create Failed.', 'New Menu')
            }
        });
    }
}
