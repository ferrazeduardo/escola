import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CadastrarComponent } from './cadastrar/cadastrar.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ListarComponent } from './listar/listar.component';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { UsuarioRoutingModule } from './usuario.routing';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    FormsModule,
    MatTableModule,
    MatButtonModule, MatDividerModule, MatIconModule
  ],
  declarations: [CadastrarComponent, ListarComponent]
})
export class UsuarioModule { }
