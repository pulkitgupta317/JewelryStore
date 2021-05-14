import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EstimationRoutingModule } from './estimation-routing.module';
import { EstimationComponent } from './estimation.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [EstimationComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    EstimationRoutingModule
  ]
})
export class EstimationModule { }
