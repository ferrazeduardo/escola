import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioRoutes } from './usuario.routing';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CadastrarComponent } from './cadastrar/cadastrar.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    UsuarioRoutes,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    ReactiveFormsModule
  ],
  declarations: [CadastrarComponent]
})
export class UsuarioModule { }
