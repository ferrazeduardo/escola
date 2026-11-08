import { HttpErrorResponse } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router ,RouterLink} from '@angular/router';
import { RedeService } from '../../../app/core/services/rede.service';
import { ProblemDetailsResponse } from '../../core/models/problemDetailsResponse';
import { CadastroUsuarioRaizComponent } from '../cadastro-usuario-raiz/cadastro-usuario-raiz.component';

@Component({
  selector: 'app-cadastro-rede',
  templateUrl: './cadastro-rede.component.html',
  imports: [ReactiveFormsModule, RouterLink, CadastroUsuarioRaizComponent],
  styleUrls: ['./cadastro-rede.component.css']
})
export class CadastroRedeComponent implements OnInit {

  private readonly fb = inject(FormBuilder);
  private readonly redeService = inject(RedeService);
  private readonly router = inject(Router);
  readonly form = this.fb.group({
    razaoSocial: ['', [Validators.required, Validators.maxLength(150)]],
    cnpj: ['', [Validators.required, Validators.pattern(/^\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2}$/)]],
  })

  readonly isLoading = signal(false);
  readonly errorMessage = signal<string | null>(null);
  readonly successMessage = signal<string | null>(null);

  readonly etapas = ['Usuário raiz', 'Rede'];
  /** 0 = usuário raiz, 1 = rede */
  readonly etapa = signal(0);
  private readonly codigoUsuario = signal<number | null>(null);

  onUsuarioCadastrado(codigo: number): void {
    this.codigoUsuario.set(codigo);
    this.etapa.set(1);
  }

  constructor() { }

  ngOnInit() {
  }


  submit(): void {
    if (this.codigoUsuario() === null) {
      this.etapa.set(0);
      return;
    }

    if (this.form.invalid || this.isLoading()) {
      this.form.markAllAsTouched();
      return;
    }

    this.errorMessage.set(null);
    this.isLoading.set(true);

    const { razaoSocial, cnpj } = this.form.getRawValue();

    this.redeService
      .salvar({
        razaoSocial: razaoSocial!.trim(),
        cnpj: cnpj!.replace(/\D/g, ''), // envia só os dígitos
        codigoUsuario: this.codigoUsuario()!,
      })
      .subscribe({
        next: () => {
          this.isLoading.set(false);
          this.successMessage.set('Rede cadastrada com sucesso! Redirecionando para o login...');
          setTimeout(() => this.router.navigateByUrl('/login'), 2000);
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
    return 'Não foi possível cadastrar a rede. Tente novamente.';
  }
}
