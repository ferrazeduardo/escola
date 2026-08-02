import { HttpErrorResponse } from '@angular/common/http';
import { Component, inject, signal } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { ApiErrorResponse } from '../../core/models/auth.model';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  private readonly fb = inject(FormBuilder);
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  readonly form = this.fb.group({
    login: ['', [Validators.required, Validators.email]],
    senha: ['', [Validators.required]],
  });

  readonly isLoading = signal(false);
  readonly errorMessage = signal<string | null>(null);
  readonly showPassword = signal(false);

  readonly currentYear = new Date().getFullYear();
  readonly highlights = [
    'Gestão centralizada de usuários e perfis',
    'Controle de acesso por redes de ensino',
    'Autenticação segura com token',
  ];

  togglePassword(): void {
    this.showPassword.update((value) => !value);
  }

  submit(): void {
    if (this.form.invalid || this.isLoading()) {
      this.form.markAllAsTouched();
      return;
    }

    this.errorMessage.set(null);
    this.isLoading.set(true);

    const { login, senha } = this.form.getRawValue();

    this.authService.login({ login: login!, senha: senha! }).subscribe({
      next: () => {
        this.isLoading.set(false);
        this.router.navigateByUrl('/dashboard');
      },
      error: (err: HttpErrorResponse) => {
        this.isLoading.set(false);
        this.errorMessage.set(this.resolveError(err));
      },
    });
  }

  private resolveError(err: HttpErrorResponse): string {
    const apiError = err.error as ApiErrorResponse | undefined;
    if (apiError?.details) {
      return apiError.details;
    }
    if (err.status === 0) {
      return 'Não foi possível conectar ao servidor. Verifique sua conexão.';
    }
    return 'Não foi possível entrar. Tente novamente.';
  }
}
