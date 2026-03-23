import type { Unidade } from '../models/iunidade';
import { api } from './axios';

export const addUnidade = (param: Unidade) =>
  api.post('/unidade/vincular', param)