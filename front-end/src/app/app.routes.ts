import { Routes } from '@angular/router';
import {ProdavnicaComponent} from "../prodavnica/prodavnica.component";
import {ViewProizvodComponent} from "../view-proizvod/view-proizvod.component";

export const routes: Routes = [
  { path: 'prodavnica', component: ProdavnicaComponent },
  { path: 'viewproizvod/:proizvodID', component: ViewProizvodComponent },
];
