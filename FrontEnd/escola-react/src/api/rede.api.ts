// src/api/usuario.api.ts
import type { Rede } from '../models/irede';
import { api } from './axios';

export const saveRede = (param: Rede) =>
  api.post('/rede/save', param)

export const obterRede = (param: number) =>
  api.post('/rede/obter', param)

export const editRede= (param: Rede) => 
  api.put('/rede/editar')