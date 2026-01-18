import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HeaderComponent } from '../../layout/header/header.component';

@NgModule({
  imports: [
    CommonModule,
    HomeComponent,
    HeaderComponent,
  ],
  declarations: []
})
export class HomeModule { }
