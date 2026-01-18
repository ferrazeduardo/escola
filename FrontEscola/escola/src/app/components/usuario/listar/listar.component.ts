import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../../shared/services/usuario.service';
import { Usuario } from '../../../shared/models/usuario';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  standalone: false,
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ListarComponent implements OnInit {
  nomeUsuario: string = '';
  usuarios: Usuario[] = [];
displayedColumns: string[] = ['id', 'nome', 'cpf','data nascimento'];
  dataSource = new MatTableDataSource<Usuario>([]);
  constructor(private _usuarioService: UsuarioService) { }

  ngOnInit() {
  }




  pesquisar() {
    this._usuarioService.listar({
      nome: this.nomeUsuario
    }).subscribe({
      next: (response: Usuario[]) => {
        this.usuarios = response as Usuario[];
        this.dataSource.data = this.usuarios;
      },
      err: (error: any) => {
        alert('Erro ao listar usuarios: ' + error.message);
      }
    })
  }

}
