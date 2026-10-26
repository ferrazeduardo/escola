import { Routes } from '@angular/router';
import { authGuard, guestGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'login' },
  {
    path: 'login',
    canActivate: [guestGuard],
    loadComponent: () => import('./features/login/login').then((m) => m.Login),
  },
  {
    path: 'dashboard',
    canActivate: [authGuard],
    loadComponent: () => import('./features/dashboard/dashboard').then((m) => m.Dashboard),
  },
  {
    path: 'cadastro-rede',
    canActivate: [guestGuard],
    loadComponent: () => import('./features/cadastro-rede/cadastro-rede.component').then((m) => m.CadastroRedeComponent),
  },
  { path: '**', redirectTo: 'login' },
];
