import { Component } from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-kontakt',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
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
        window.open("https://maps.app.goo.gl/jQsVRovNwJhVarDv5");
    }

    protected readonly alert = alert;
  Subject: string ="";
  mailText: string = "";

    mailBoxOtvoriZatvori() {
      this.mailBoxOtvoren=!this.mailBoxOtvoren;
    }
    slanjeMaila(){
      const mailtoUrl = `mailto:egymzalik@gmail.com?subject=${encodeURIComponent(this.Subject)}&body=${encodeURIComponent(this.mailText)}`;
      window.open(mailtoUrl);
      this.mailBoxOtvoren=false;
    }
}
