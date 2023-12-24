import { Component } from '@angular/core';
import {PtopComponent} from "../ptop/ptop.component";
import {PleftComponent} from "../pleft/pleft.component";
import {PmainComponent} from "../pmain/pmain.component";
import {AppComponent} from "../app/app.component";

@Component({
  selector: 'app-prodavnica',
  imports: [
    PtopComponent,
    PleftComponent,
    PmainComponent,
    AppComponent
  ],
  standalone: true,
  templateUrl: './prodavnica.component.html',
  styleUrl: './prodavnica.component.css'
})
export class ProdavnicaComponent {

}
