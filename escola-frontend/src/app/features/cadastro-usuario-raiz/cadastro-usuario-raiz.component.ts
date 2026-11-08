import { HttpErrorResponse } from '@angular/common/http';
import { Component, inject, output, signal } from '@angular/core';
import { AbstractControl, FormBuilder, ReactiveFormsModule, ValidationErrors, Validators } from '@angular/forms';
import { UsuarioService } from '../../core/services/usuario.service';
import { ProblemDetailsResponse } from '../../core/models/problemDetailsResponse';

function senhasIguais(group: AbstractControl): ValidationErrors | null {
  const senha = group.get('senha')?.value;
  const confirmar = group.get('confirmarSenha')?.value;
  return senha && confirmar && senha !== confirmar ? { senhasDiferentes: true } : null;
}

@Component({
  selector: 'app-cadastro-usuario-raiz',
  templateUrl: './cadastro-usuario-raiz.component.html',
  imports: [ReactiveFormsModule],
})
export class CadastroUsuarioRaizComponent {
  private readonly fb = inject(FormBuilder);
  private readonly usuarioService = inject(UsuarioService);

  /** Emite o código do usuário raiz criado. */
  readonly concluido = output<number>();

  readonly form = this.fb.group(
    {
      nome: ['', [Validators.required, Validators.maxLength(150)]],
      cpf: ['', [Validators.required, Validators.pattern(/^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$/)]],
      dataNascimento: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirmarSenha: ['', [Validators.required]],
    },
    { validators: senhasIguais },
  );

  readonly isLoading = signal(false);
  readonly errorMessage = signal<string | null>(null);

  invalido(campo: keyof typeof this.form.controls): boolean {
    const c = this.form.controls[campo];
    return c.invalid && c.touched;
  }

  submit(): void {
    if (this.form.invalid || this.isLoading()) {
      this.form.markAllAsTouched();
      return;
    }

    this.errorMessage.set(null);
    this.isLoading.set(true);

    const { nome, cpf, dataNascimento, email, senha } = this.form.getRawValue();

    this.usuarioService
      .salvar({
        nome: nome!.trim(),
        cpf: cpf!.replace(/\D/g, ''),
        dataNascimento: dataNascimento!,
        email: email!.trim(),
        senha: senha!,
        ehRaiz: true, // usuário raiz do sistema
      })
      .subscribe({
        next: (res) => {
          this.isLoading.set(false);
          this.concluido.emit(res.codigo);
        },
        error: (err: HttpErrorResponse) => {
          this.isLoading.set(false);
          this.errorMessage.set(this.resolveError(err));
        },
      });
  }

  private resolveError(err: HttpErrorResponse): string {
    const apiError = err.error as ProblemDetailsResponse | undefined;
    if (err.status === 400 && apiError?.detail) {
      return apiError.detail;
    }
    if (err.status === 401) {
      return 'Cadastro não autorizado.';
    }
    if (err.status === 0) {
      return 'Não foi possível conectar ao servidor. Verifique sua conexão.';
    }
    return 'Não foi possível cadastrar o usuário. Tente novamente.';
  }
}
