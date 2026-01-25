import { Routes } from '@angular/router';

export const usuarioRoutes: Routes = [
  {
    path: 'cadastrar',
    loadComponent: () =>
      import('./cadastrar/cadastrar.component')
        .then(m => m.CadastrarComponent)
  },
  {
    path: 'editar/:id',
    loadComponent: () =>
      import('./cadastrar/cadastrar.component')
        .then(m => m.CadastrarComponent)
  },
  {
    path: 'listar',
    loadComponent: () =>
      import('./listar/listar.component')
        .then(m => m.ListarComponent)
  }
];
