import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UsuarioService } from '../../../shared/services/usuario.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cadastrar',
  templateUrl: './cadastrar.component.html',
  styleUrls: ['./cadastrar.component.css'],
  imports: [
    CommonModule,
    ReactiveFormsModule]
})
export class CadastrarComponent implements OnInit {

  form!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private _usuarioService: UsuarioService
  ) {
    this.form = this.fb.group({
      nome: ['', Validators.required],
      cpf: ['', Validators.required],
      dataNascimento: [null, Validators.required],
      email: ['', [Validators.required, Validators.email]],
      login: ['', Validators.required],
      senha: ['', Validators.required]
    });
  }

  ngOnInit() {
  }

  salvar(): void {
    if (this.form.invalid) {
      return;
    }

    const usuario = this.form.value;

    this._usuarioService.save(usuario).subscribe({
      next: (response: any) => {
        alert('Usuario cadastrado com sucesso!');
      },
      err: (error: any) => {
        alert('Erro ao cadastrar usuario: ' + error.message);
      }
    })
  }
}
