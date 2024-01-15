import { Routes } from '@angular/router';
import {ProdavnicaComponent} from "../prodavnica/prodavnica.component";
import {ViewProizvodComponent} from "../view-proizvod/view-proizvod.component";
import {KorpaComponent} from "../korpa/korpa.component";
import {ObavijestiComponent} from "./obavijesti/obavijesti.component";
import {PrijaviSeComponent} from "./prijavi-se/prijavi-se.component";
import {RegistrujSeComponent} from "./registruj-se/registruj-se.component";
import {ClanarinaComponent} from "./clanarina/clanarina.component";

export const routes: Routes = [
  {path:'', redirectTo:'/obavijesti', pathMatch:'full'},
  { path: 'prodavnica', component: ProdavnicaComponent },
  { path: 'viewproizvod/:proizvodID', component: ViewProizvodComponent },
  { path: 'korpa', component: KorpaComponent },
  {path:'obavijesti',component:ObavijestiComponent},
  {path:'prijavi-se',component:PrijaviSeComponent},
  {path:'registruj-se',component:RegistrujSeComponent},
  {path:'clanarina',component: ClanarinaComponent}
];
