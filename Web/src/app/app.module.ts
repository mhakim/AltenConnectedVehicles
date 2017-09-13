import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FlexLayoutModule } from "@angular/flex-layout";
import {MdButtonModule, MdRadioModule} from '@angular/material';


import { AppComponent } from './app.component';
import { VehicleComponent } from './vehicle/vehicle.component';

import { DataService } from './data.service';

@NgModule({
  declarations: [
    AppComponent,
    VehicleComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FlexLayoutModule,
    MdButtonModule, 
    MdRadioModule
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
