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

  save(param: any) {
    const uri: string = '5151/usuario/save';
    return this.apiBase.post(`${this.baseApiPath + uri}`, undefined, param);
  }

  listar(param: any) {
    const uri: string = '5151/usuario/listar';
    return this.apiBase.post(`${this.baseApiPath + uri}`, undefined, param);
  }
}
