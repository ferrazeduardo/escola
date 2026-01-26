import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html'
})
export class FormularioComponent {

  nome = '';
  usuarios: any[] = [];

  constructor(private http: HttpClient) {}

  buscar() {
    this.http.post<any[]>(
      'http://localhost:5151/usuario/listar',
      { nome: this.nome }
    ).subscribe(res => {
      console.log('resposta', res);
      this.usuarios = res;
    });
  }
}
