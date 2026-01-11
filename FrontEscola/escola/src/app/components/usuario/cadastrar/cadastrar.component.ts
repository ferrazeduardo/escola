import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from '../../../shared/services/usuario.service';
@Component({
  standalone: false,
  selector: 'app-cadastrar',
  templateUrl: './cadastrar.component.html',
  styleUrls: ['./cadastrar.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
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

    console.log('UsuarioSaveInput:', usuario);

    this._usuarioService.save(usuario).subscribe({
      next: (response: any) => {
        alert('Usuario cadastrado com sucesso!');
      },
      err: (error: any) => {
        alert('Erro ao cadastrar usuario: ' + error.message);
      }
    })

    // aqui você chama o backend
  }

}
