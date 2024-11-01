import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule, CardModule, FormModule, ModalModule } from '@coreui/angular';
import { ReactiveFormsModule } from '@angular/forms';
import { EnumDescriptionPipe } from '../pipes/enum-description.pipe';
import { EnumToSelectPipe } from '../pipes/enum-to-select.pipe';
import { LoadingComponent } from "../components/loading/loading.component";

const PIPES = [
  EnumDescriptionPipe,
  EnumToSelectPipe
];

const CORE = [
  CommonModule,
  CardModule,
  ReactiveFormsModule,
  LoadingComponent
];

const COREUI = [
  ModalModule,
  FormModule,
  ButtonModule
];

@NgModule({
  declarations: [
    ...PIPES
  ],
  imports: [
    ...CORE,
    ...COREUI
  ],
  exports: [
    ...CORE,
    ...COREUI,
    ...PIPES
  ]
})
export class SharedModule {}
