import { Component } from '@angular/core';
import { CommonModule } from "@angular/common";

@Component({
  selector: 'app-pleft',
  templateUrl: './pleft.component.html',
  styleUrls: ['./pleft.component.css'],
  standalone: true,
  imports: [CommonModule],
})
export class PleftComponent {
  filteriPrikazani: boolean;
  prikazaneKategorije: boolean;
  prikazaniBrendovi: boolean;

  isKategorijeHovered: boolean = false;
  isBrendoviHovered: boolean = false;

  constructor() {
    this.filteriPrikazani = false;
    this.prikazaneKategorije = false;
    this.prikazaniBrendovi = false;
  }

  prikaziFiltere() {
    this.filteriPrikazani = !this.filteriPrikazani;
  }

  prikaziKategorije() {
    this.prikazaneKategorije = !this.prikazaneKategorije;
  }

  onKategorijeMouseEnter() {
    this.isKategorijeHovered = true;
  }

  onKategorijeMouseLeave() {
    this.isKategorijeHovered = false;
  }

  prikaziBrendove() {
    this.prikazaniBrendovi = !this.prikazaniBrendovi;
  }

  onBrendoviMouseEnter() {
    this.isBrendoviHovered = true;
  }

  onBrendoviMouseLeave() {
    this.isBrendoviHovered = false;
  }
}
