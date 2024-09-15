import { Component } from '@angular/core';
import {FormsModule} from "@angular/forms";
import {SharedDataService} from "../shared-data-service";
import {Router} from "@angular/router";
declare function porukaSuccess(m:string):any;
declare function porukaError(m:string):any;

@Component({
  selector: 'app-ptop',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './ptop.component.html',
  styleUrl: './ptop.component.css'
})
export class PtopComponent {

   _inputValue: string = '';
constructor(private sharedDataService: SharedDataService, private router:Router) {
}
  TraziZaInput() {
  if(this.router.url != '/prodavnica'){
    this.router.navigate(['/prodavnica']);
  }
    this.sharedDataService.updateInputValue(this._inputValue);
    this._inputValue = "";
  }

  OtvoriKorpu() {
    let korisnikString = window.localStorage.getItem("korisnik")??"";
    if(korisnikString == "") {
      porukaError("Morate biti prijavljeni da biste mogli pregledati korpu");
      this.router.navigate(['/prijavi-se']);
      return;
    }
    const korisnikObject = JSON.parse(korisnikString);
    const korisnikId = korisnikObject.autentifikacijaToken.korisnickiNalogId;
    if(this.router.url != '/korpa'){
      this.router.navigate([`/korpa/${korisnikId}`]);
    }
  }
}
