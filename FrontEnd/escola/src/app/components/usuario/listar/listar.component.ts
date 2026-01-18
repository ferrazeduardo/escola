import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../../shared/models/usuario';
import { UsuarioService } from '../../../shared/services/usuario.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.css'],
  imports: [CommonModule,FormsModule],
})
export class ListarComponent implements OnInit {

  nomeUsuario: string = '';
  usuarios: Usuario[] = [];
  displayedColumns: string[] = ['id', 'nome', 'cpf', 'datanascimento'];
  constructor(private _usuarioService: UsuarioService) { }

  ngOnInit() {
  }




  pesquisar() {
    this._usuarioService.listar({
      nome: this.nomeUsuario
    }).subscribe({
      next: (response: Usuario[]) => {
        this.usuarios = response;
      },
      err: (error: any) => {
        alert('Erro ao listar usuarios: ' + error.message);
      }
    })
  }

}
