import { HttpClient } from '@angular/common/http';
import { Injectable, computed, signal } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { environment } from '../../../environments/environment';
import { LoginRequest, LoginResponse } from '../models/auth.model';

interface TokenClaims {
  userId?: string;
  email?: string;
  exp?: number;
  permissoes?: string[]
}

const TOKEN_KEY = 'escola_token';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly tokenSignal = signal<string | null>(sessionStorage.getItem(TOKEN_KEY));
  readonly permissoes = computed(() => this.currentUser()?.permissoes || []);

  readonly isAuthenticated = computed(() => {
    const claims = this.decodeToken(this.tokenSignal());
    return !!claims && !this.isExpired(claims);
  });

  readonly currentUser = computed(() => this.decodeToken(this.tokenSignal()));

  constructor(private readonly http: HttpClient) { }

  temPermissao(codigo?: string): boolean{
    if(!codigo) return true;
    const lista = this.permissoes();
    if(lista.length === 0) return true; // apagar, apenas para testar
    return lista.includes(codigo)
  }

  login(credentials: LoginRequest): Observable<LoginResponse> {
    return this.http
      .post<LoginResponse>(`${environment.apiUrl}/login`, credentials)
      .pipe(tap((response) => this.setToken(response.token)));
  }

  logout(): void {
    sessionStorage.removeItem(TOKEN_KEY);
    this.tokenSignal.set(null);
  }

  getToken(): string | null {
    return this.tokenSignal();
  }

  private setToken(token: string): void {
    sessionStorage.setItem(TOKEN_KEY, token);
    this.tokenSignal.set(token);
  }

  private decodeToken(token: string | null): TokenClaims | null {
    if (!token) {
      return null;
    }

    try {
      const payload = token.split('.')[1];
      const normalized = payload.replace(/-/g, '+').replace(/_/g, '/');
      const json = decodeURIComponent(
        atob(normalized)
          .split('')
          .map((c) => '%' + c.charCodeAt(0).toString(16).padStart(2, '0'))
          .join(''),
      );
      return JSON.parse(json);
    } catch {
      return null;
    }
  }

  private isExpired(claims: TokenClaims): boolean {
    if (!claims.exp) {
      return false;
    }
    return Date.now() >= claims.exp * 1000;
  }
}
