import type { Perfil } from '../models/iperfil';
import { api } from './axios';

export const savePerfil = (param: Perfil) =>
  api.post('/perfil/save', param)