import { Injectable } from '@angular/core';
import { Http, URLSearchParams, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs';

import { VehicleFilters } from './models/vehicleFilters';
import { Stamp } from './models/stamp';
import { Customer } from './models/customer';
import { Vehicle } from './models/vehicle';

@Injectable()
export class DataService {
  baseUrl: string = 'http://localhost:53000/';
  //'http://connectedvehicles.azurewebsites.net/';

  constructor(private http: Http) {

  }

  getVehicles(filters: VehicleFilters): Observable<Vehicle[]> {
    var uri = this.baseUrl + 'api/vehicles';
    var params = this.buildVehicleFilters(filters);

    var observableResult = this.http
      .get(uri, { search: params })
      .map((r: Response) => r.json());

    return observableResult;
  }

  getAllCustomers(): Observable<Customer[]> {
    var uri = this.baseUrl + 'api/customers';

    var observableResult = this.http.get(uri)
      .map((r: Response) => r.json());

    return observableResult;
  }

  sendRandomStamps() {
    this.getVehicles(null)
      .subscribe((r: Vehicle[]) => {
        for (let i: number = 0; i < r.length; i++) {
          var randomAlive = Math.random() >= 0.5;
          if (randomAlive) this.addStamp(r[i].id);
        }
      });
  }

  private addStamp(id: string) {
    var uri = this.baseUrl + 'api/stamps';
    var stamp = new Stamp();
    stamp.id = id;
    var observableResult = this.http.post(uri, stamp)
      .subscribe(() => console.log("stamp added"));
  }

  private buildVehicleFilters(filters: VehicleFilters): URLSearchParams {
    let params: URLSearchParams = new URLSearchParams();
    if (filters == null) filters = new VehicleFilters();
    if (filters.customerId) params.set('customerId', filters.customerId);
    if (filters.vehicleId) params.set('vehicleId', filters.vehicleId);
    if (filters.isAlive != null) params.set('isAlive', filters.isAlive.toString());

    return params;
  }



}
