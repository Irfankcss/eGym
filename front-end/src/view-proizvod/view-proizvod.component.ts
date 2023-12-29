import { Component } from '@angular/core';
import {PtopComponent} from "../ptop/ptop.component";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-view-proizvod',
  standalone: true,
  imports: [
    PtopComponent,
    FormsModule
  ],
  templateUrl: './view-proizvod.component.html',
  styleUrl: './view-proizvod.component.css'
})
export class ViewProizvodComponent {
  kolicina: number = 1;

  uvecaj() {
    this.kolicina++;
  }

  umanji() {
    if (this.kolicina > 1) {
      this.kolicina--;
    }
  }

  onInputChange() {
    if(this.kolicina < 1) {
      this.kolicina = 1;
    }
  }

  dodajuKorpu() {
    if(this.kolicina==1){
      alert("Uspjesno ste dodali 1 proizvod u korpu");
    }else{
    alert("Uspjesno ste dodali " + this.kolicina + " proizvoda u korpu");
  }}
}
