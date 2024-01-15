import { Component } from '@angular/core';
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-kontakt',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './kontakt.component.html',
  styleUrl: './kontakt.component.css'
})
export class KontaktComponent {
  postaHovered:boolean=false;
  telefonHovered:boolean=false;
  lokacijaHovered: boolean = false;
  mailBoxOtvoren:boolean=false;

  postaEnter() {
    this.postaHovered=true;
  }
  postaLeave() {
    this.postaHovered=false;
  }

  telefonEnter() {
    this.telefonHovered=true;

  }

    telefonLeave() {
    this.telefonHovered=false
  }

    lokacijaEnter() {
      this.lokacijaHovered = true;
    }

    lokacijaLeave() {
      this.lokacijaHovered = false;
    }

    idiNaLokaciju() {
        window.open("https://maps.app.goo.gl/CbQp7j2vSdKDiizP9");
    }

    protected readonly alert = alert;

    mailBoxOtvoriZatvori() {
        this.mailBoxOtvoren = !this.mailBoxOtvoren
    }
}
