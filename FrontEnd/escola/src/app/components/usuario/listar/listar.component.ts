import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../../shared/models/usuario';
import { UsuarioService } from '../../../shared/services/usuario.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { RouterLink } from "@angular/router";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.css'],
  imports: [CommonModule, FormsModule, RouterLink,FontAwesomeModule],
})
export class ListarComponent implements OnInit {
  faEdit = faEdit;
  nomeUsuario: string = '';
  usuarios: Usuario[] = [];
  constructor(private _usuarioService: UsuarioService) { }

  ngOnInit() {
  }




  pesquisar() {
    this._usuarioService.listar({
      nome: this.nomeUsuario
    }).subscribe({
      next: (response: any) => {
        this.usuarios = response.body;
        console.log(this.usuarios)
      },
      error: (error: any) => {
        alert('Erro ao listar usuarios: ' + error.message);
      }
    })
  }

}
