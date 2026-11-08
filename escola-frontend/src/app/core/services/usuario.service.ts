import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { UsuarioSaveRequest } from '../models/usuarioSaveRequest';
import { UsuarioSaveResponse } from '../models/usuarioSaveResponse';

@Injectable({ providedIn: 'root' })
export class UsuarioService {
  private readonly http = inject(HttpClient);

  salvar(usuario: UsuarioSaveRequest): Observable<UsuarioSaveResponse> {
    // Kong: /auth (strip_path) -> UsuarioController [Route("Usuario")] -> [HttpPost("save")]
    return this.http.post<UsuarioSaveResponse>(`${environment.apiUrl}/auth/Usuario/save`, usuario);
  }
}
