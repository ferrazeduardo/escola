import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      {
        path: 'usuario',
        loadChildren: () =>
          import('./components/usuario/usuario.routing')
            .then(m => m.usuarioRoutes)
      }
    ]
  }
];
