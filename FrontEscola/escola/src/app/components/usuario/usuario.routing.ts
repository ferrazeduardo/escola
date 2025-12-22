import { Routes, RouterModule } from '@angular/router';
import { CadastrarComponent } from './cadastrar/cadastrar.component';

const routes: Routes = [
  {
    path: 'cadastrar',
    component: CadastrarComponent
  },
];

export const UsuarioRoutes = RouterModule.forChild(routes);
