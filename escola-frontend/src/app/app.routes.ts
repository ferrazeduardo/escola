import { Routes } from '@angular/router';
import { authGuard, guestGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'dashboard' },
  {
    path: 'login',
    canActivate: [guestGuard],
    loadComponent: () => import('./features/login/login').then((m) => m.Login),
  },
  {
    path: 'cadastro-rede',
    canActivate: [guestGuard],
    loadComponent: () => import('./features/cadastro-rede/cadastro-rede.component').then((m) => m.CadastroRedeComponent),
  },
  {
    path: '',
    canActivate: [authGuard],
    loadComponent: () => import('./layout/layout.component').then((m) => m.LayoutComponent),
    children: [
       { path: 'dashboard', loadComponent: () => import('./features/dashboard/dashboard').then((m) => m.Dashboard) },
      // { path: 'academico/alunos/novo', loadComponent: () => import('./features/academico/cadastro-aluno/cadastro-aluno').then((m) => m.CadastroAluno) },
      // { path: 'academico/matricula',   loadComponent: () => import('./features/academico/matricula/matricula').then((m) => m.Matricula) },
      // { path: 'academico/turmas/nova', loadComponent: () => import('./features/academico/criar-turma/criar-turma').then((m) => m.CriarTurma) },
    ]
  },
  { path: '**', redirectTo: 'login' },
];
