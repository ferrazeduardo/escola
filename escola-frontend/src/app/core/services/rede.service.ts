import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { SaveRedeRequest } from '../models/saveRedeRequest';
import { SaveRedeResponse } from '../models/saveRedeResponse';

@Injectable({ providedIn: 'root' })
export class RedeService {

 private readonly http = inject(HttpClient);

  salvar(rede: SaveRedeRequest): Observable<SaveRedeResponse> {
    // Kong: /redes (strip_path) -> RedeController [Route("Rede")] -> [HttpPost("save")]
    return this.http.post<SaveRedeResponse>(`${environment.apiUrl}/redes/Rede/save`, rede);
  }

}
