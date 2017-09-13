import { Component, OnInit } from '@angular/core';
import { Vehicle } from './models/vehicle';
import { Customer } from './models/customer';
import { VehicleFilters } from './models/vehicleFilters';

import { DataService } from './data.service';
import { Observable } from "rxjs";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  customers: Customer[] = [];
  vehicles: Vehicle[] = [];
  filters: VehicleFilters = new VehicleFilters();
  loading: boolean = false;
  timer: number = 0;
  stampsSimer: number = 0;

  constructor(private dataService: DataService) {
  }

  ngOnInit() {
    this.loadVehicles();
    this.loadCustomers();
    this.initializeRefresherTimer();
    // this.initializeRandomStampsTimer();
  }


  initializeRefresherTimer() {
    return Observable
      .interval(1000)
      .subscribe(() => {
        this.timer++;
        if (this.timer >= 15) {
          this.timer = 0;
          this.loadVehicles();
        }
      });
  }


  // initializeRandomStampsTimer() {
  //   return Observable
  //     .interval(1000)
  //     .subscribe(() => {
  //       this.stampsSimer++;
  //       if (this.stampsSimer >= 45) {
  //         this.stampsSimer = 0;
  //         this.dataService.sendRandomStamps();
  //       }
  //     });
  // }


  loadVehicles() {
    this.loading = true;
    this.dataService.getVehicles(this.filters).subscribe(
      (r: Vehicle[]) => {
        this.vehicles = r;
        this.loading = false;
      }
    )
  }

  loadCustomers() {
    this.dataService.getAllCustomers().subscribe(
      (r: Customer[]) => this.customers = r
    )
  }

  updateCustomerIdFilters(id: string) {
    this.filters.customerId = id;
    this.loadVehicles();
  }

  updateAliveFilters(alive: boolean) {
    this.filters.isAlive = alive;
    this.loadVehicles();
  }

}
