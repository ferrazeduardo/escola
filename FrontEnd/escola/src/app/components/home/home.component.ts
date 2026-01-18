import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from "@angular/router";
import { HeaderComponent } from "../../layout/header/header.component";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  imports: [RouterOutlet, HeaderComponent]
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
