import { Component } from '@angular/core';
import {ObavijestDodajComponent} from "./obavijest-dodaj/obavijest-dodaj.component";
import {CommonModule} from "@angular/common";
import {ObavijestiUrediComponent} from "./obavijesti-uredi/obavijesti-uredi.component";
import {ObavijestiUkloniComponent} from "./obavijesti-ukloni/obavijesti-ukloni.component";

@Component({
  selector: 'app-obavijesti-kontrola',
  standalone: true,
  imports: [
    ObavijestDodajComponent,
    CommonModule,
    ObavijestiUrediComponent,
    ObavijestiUkloniComponent
  ],
  templateUrl: './obavijesti-kontrola.component.html',
  styleUrl: './obavijesti-kontrola.component.css'
})
export class ObavijestiKontrolaComponent {
  IsDodajVidljivo: boolean = false;
  IsUrediVidljivo: boolean = false;
  IsObrisiVidljivo: boolean = false;

}
