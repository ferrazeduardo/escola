import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
   private fb: FormBuilder
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

    // aqui você chama o backend
  }

}
