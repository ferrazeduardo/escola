import { Component, computed, inject, OnInit } from '@angular/core';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { MENU } from './Menu';

@Component({
  selector: 'app-layout',
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {
  private readonly auth = inject(AuthService);
  private readonly router = inject(Router);
  readonly user = this.auth.currentUser;

  readonly menu = computed(() =>
    MENU
      .map((grupo) => ({
        ...grupo,
        filhos: (grupo.filhos ?? []).filter((f) => this.auth.temPermissao(f.permissao))
      })))

  constructor() { }

  ngOnInit() {
  }


  logout() {
    this.auth.logout();
    this.router.navigate(['/login']);
  }

}
