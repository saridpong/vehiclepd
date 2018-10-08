import { CarsService } from '../../../services/cars.services';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { CarTypeService } from '../../../services/cartype.services';

@Component({
  templateUrl: 'cars-update.component.html'
})
export class CarsUpdateComponent implements OnInit {
  roots: any = [];
  items: any;
  mCriteria: any = {
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
    vehicleInsuranceType: '',
    carType: {}
  };
  constructor(
    private route: Router,
    private routeActive: ActivatedRoute,
    private toastr: ToastrService,
    private location: Location,
    private cars: CarsService,
    private cartype: CarTypeService
  ) {
    this.items = {}
    this.routeActive.params.subscribe(params => {
      const param = { vehicleId: params['id'] };
      this.cars.findbyid(param).subscribe(result => {
        this.mCriteria = result.vehicle;
      });
    });
  }
  ngOnInit() {

    const carCriteria = {
      status: 1
    }
    this.cartype.find(carCriteria).subscribe(result => {
      this.items = result;
    })
  }

  onSubmit() {
    this.cars.update(this.mCriteria).subscribe(result => {
      if (result.responseStatus === 1) {
        this.toastr.success('Update Success.', 'Update Car');
      } else {
        this.toastr.error('Create Failed.', 'New Car');
      }
    });
  }

  onBack() {
    this.location.back();
  }
}
