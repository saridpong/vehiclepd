import { CarsService } from './../../../services/cars.services';
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
    private location: Location,
    private cars: CarsService
  ) {
    this.mCriteria = {
      vehicleCode: '',
      vehicleBrand: '',
      vehicleModel: '',
      vehicleFuelType: '',
      vehicleDate: '',
      vehicleCost: '',
      vehicleTypeCode: '',
      vehicleYear: '',
      vehicleAsset: '',
      vehicleInsurance: '',
      vehicleInsuranceType: ''
    };
  }
  ngOnInit() {}

  onSubmit() {
    this.cars.add(this.mCriteria).subscribe(result => {
      if (result.responseStatus === 1) {
        this.toastr.success('Create Success.', 'New Car');
        this.mCriteria = {
          vehicleCode: '',
          vehicleBrand: '',
          vehicleModel: '',
          vehicleFuelType: '',
          vehicleDate: '',
          vehicleCost: '',
          vehicleTypeCode: '',
          vehicleYear: '',
          vehicleAsset: '',
          vehicleInsurance: '',
          vehicleInsuranceType: ''
        };
      } else {
        this.toastr.error('Create Failed.', 'New Car');
      }
    });
  }

  onBack() {
    this.location.back();
  }
}
