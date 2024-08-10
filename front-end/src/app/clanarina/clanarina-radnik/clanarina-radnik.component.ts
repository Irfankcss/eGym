import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Mojconfig} from "../../moj-config";
import {Clan} from "./Clan";
import {KeyValuePipe, NgForOf} from "@angular/common";
import {Radnik} from "./Radnik";

@Component({
  selector: 'app-clanarina-radnik',
  standalone: true,
  imports: [HttpClientModule, NgForOf, KeyValuePipe],
  templateUrl: './clanarina-radnik.component.html',
  styleUrl: './clanarina-radnik.component.css'
})
export class ClanarinaRadnikComponent implements OnInit{

  listaClanova:any;
  radnikPodaci:any;
  constructor(public httpClient:HttpClient) {
    if(this.isRadnik()){
      let radnikID = this.dohvatiLogiranogKorisnika().autentifikacijaToken.korisnickiNalog.id;
      let url = Mojconfig.adresa_servera + `/Obradi/RadnikGetByEndpoint/GetByID?ID=${radnikID}`;
      this.httpClient.get<Radnik>(url).subscribe(x=>{
        this.radnikPodaci = x.radnici;
      })
    }
  }
  ngOnInit(): void {
    let url = Mojconfig.adresa_servera + `/Clan/GetAll`;
    this.httpClient.get<Clan>(url).subscribe(x=>{
      this.listaClanova = x.clanovi;
    })
  }
  dohvatiLogiranogKorisnika(){
    let token = window.localStorage.getItem("korisnik")??"";
    try {
      return JSON.parse(token);
    }
    catch (e){
      return null;
    }
  }
  isRadnik(){
    return this.dohvatiLogiranogKorisnika()?.autentifikacijaToken.korisnickiNalog.isRadnik;
  }

}
