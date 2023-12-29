import { Routes } from '@angular/router';

import {ProizvodViewComponent} from "../proizvod-view/proizvod-view.component";

export const routes: Routes = [
  { path: 'proizvodview/:proizvodid', component: ProizvodViewComponent },
];
