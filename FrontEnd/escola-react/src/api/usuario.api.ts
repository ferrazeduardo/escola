// src/api/usuario.api.ts
import type { Usuario } from '../models/iusuario';
import { api } from './axios';

export const listarUsuarios = (nome?: string) =>
  api.post('/usuario/listar', { nome });


export const saveUsuario = (param: Usuario) =>
  api.post('/usuario/save', param)