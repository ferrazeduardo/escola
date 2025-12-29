import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { ApibaseService } from './apibase.service';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  protected baseApiPath = environment.baseApiPath;
  constructor(
    private apiBase: ApibaseService
  ) { }

  cadastrar(param: any) {
    const uri: string = '/usuario/cadastrar';
    return this.apiBase.post(`${this.baseApiPath + uri}`, undefined, param);
  }
}
