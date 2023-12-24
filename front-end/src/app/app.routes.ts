import { Routes } from '@angular/router';
import {ProdavnicaComponent} from "../prodavnica/prodavnica.component";
import {ProizvodViewComponent} from "../proizvod-view/proizvod-view.component";
import {ObavijestiComponent} from "./obavijesti/obavijesti.component";

export const routes: Routes = [
  { path: 'prodavnica', component: ProdavnicaComponent },
  { path: 'proizvod/:id', component: ProizvodViewComponent },
  {path:'obavijesti', component: ObavijestiComponent}
];
