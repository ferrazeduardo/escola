import { Component, OnInit } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  imports: [MatButtonModule, MatMenuModule, RouterModule],
})
export class HeaderComponent implements OnInit {
  menu: any;

  constructor() { }

  ngOnInit() {
  }

}
