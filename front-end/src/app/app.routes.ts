import { Routes } from '@angular/router';
import {ProdavnicaComponent} from "../prodavnica/prodavnica.component";
import {ProizvodViewComponent} from "../proizvod-view/proizvod-view.component";
import {ObavijestiComponent} from "./obavijesti/obavijesti.component";
import {PrijaviSeComponent} from "./prijavi-se/prijavi-se.component";
import {RegistrujSeComponent} from "./registruj-se/registruj-se.component";

export const routes: Routes = [
  { path: 'prodavnica', component: ProdavnicaComponent },
  { path: 'proizvod/:id', component: ProizvodViewComponent },
  {path:'obavijesti', component: ObavijestiComponent},
  {path:'prijavi-se',component: PrijaviSeComponent},
  {path:'registruj-se',component: RegistrujSeComponent}
];
