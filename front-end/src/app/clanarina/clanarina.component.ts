import { Component } from '@angular/core';
import {NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-clanarina',
  standalone: true,
  imports: [
    NgIf,
    FormsModule
  ],
  templateUrl: './clanarina.component.html',
  styleUrl: './clanarina.component.css'
})
export class ClanarinaComponent {
  isVidljivo = false;
  kod:string = '';
  tipMjesecne:string = '';
  datumPocetkaMjesecne: string = '';

  obrisiPodatke() {
      this.kod = '';
      this.tipMjesecne = '';
      this.datumPocetkaMjesecne = '';
      this.isVidljivo = false;
  }
}
