import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Mojconfig} from "../../moj-config";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-obavijest-dodaj',
  standalone: true,
  imports: [
    HttpClientModule,
    FormsModule
  ],
  templateUrl: './obavijest-dodaj.component.html',
  styleUrl: './obavijest-dodaj.component.css'
})
export class ObavijestDodajComponent implements OnInit{
    ngNaslov:any;
    ngSadrzaj:any;
    ngSlika:any;

    constructor(public httpClient:HttpClient) {
    }

  ngOnInit(): void {

  }
  dodajNovuObavijest() {
    let url = Mojconfig.adresa_servera + '/Obradi/ObavijestiDodajEndpoint';
    let requestBody = {
      "datumObjave": new Date(),
      "naslov": this.ngNaslov,
      "text": this.ngSadrzaj,
      "slika": this.ngSlika,
    }
    this.httpClient.post(url,requestBody).subscribe(x=>{
      alert('Uspjesno dodana nova obavijest');
    })
  }
}
