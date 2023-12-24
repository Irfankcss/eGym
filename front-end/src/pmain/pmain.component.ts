import { Component } from '@angular/core';
import {routes} from "../app/app.routes";
import {ProizvodViewComponent} from "../proizvod-view/proizvod-view.component";
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-pmain',
  standalone: true,
  imports: [ProizvodViewComponent, RouterLink],
  templateUrl: './pmain.component.html',
  styleUrl: './pmain.component.css'
})
export class PmainComponent {
}
