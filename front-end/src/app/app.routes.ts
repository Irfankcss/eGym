import { Routes } from '@angular/router';
import {ProdavnicaComponent} from "../prodavnica/prodavnica.component";
import {ProizvodViewComponent} from "../proizvod-view/proizvod-view.component";

export const routes: Routes = [
  { path: 'prodavnica', component: ProdavnicaComponent },
  { path: 'proizvod/:id', component: ProizvodViewComponent },
];
