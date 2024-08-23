import {Component, OnInit} from '@angular/core';
import {EvidencijaDolazaka} from "./evidencija-dolazaka";
import {NgForOf} from "@angular/common";
import {Mojconfig} from "../../moj-config";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {LogiraniClan} from "./logiraniClan";

@Component({
  selector: 'app-clanarina-korisnik',
  standalone: true,
  imports: [
    NgForOf,
    HttpClientModule
  ],
  templateUrl: './clanarina-korisnik.component.html',
  styleUrl: './clanarina-korisnik.component.css'
})
export class ClanarinaKorisnikComponent implements OnInit{

  logiraniClan:any;
  trenutniDatum = new Date();
  evidencija:EvidencijaDolazaka[] = [];
  prviBroj:number = 0;
  drugiBroj:number = 0;
  treciBroj:number = 0;
  prolaz: boolean = true;
  constructor(public httpClient:HttpClient) {
  }
  ngOnInit(): void {
    for (let i=1;i<3;i++){
      let randomNumber = this.getRandomInt(1,10);
      let izracunatiDatum = new Date(this.trenutniDatum);


      switch(i) {
        case 1:
          this.prviBroj = randomNumber;
          izracunatiDatum.setDate(this.trenutniDatum.getDate() - this.prviBroj);
          break;

        case 2:
          this.drugiBroj = randomNumber;
          if (randomNumber === this.prviBroj) {
            do {
              this.drugiBroj = this.getRandomInt(1, 10);
            } while (randomNumber != this.prviBroj);
          }
          izracunatiDatum.setDate(this.trenutniDatum.getDate() - this.drugiBroj);
          break;
        default:
          break;
      }
      this.evidencija.push({redniBroj: i, datum: new Date(izracunatiDatum.getFullYear(),izracunatiDatum.getMonth(),izracunatiDatum.getDate(),this.getRandomInt(1,24),this.getRandomInt(1,59),this.getRandomInt(1,59)), vrijemeIzlaska: randomNumber, vrijemeUlaska: randomNumber})

      this.evidencija.sort((a, b) => a.datum.getTime() - b.datum.getTime());
    }
    let url = Mojconfig.adresa_servera + `/Obradi/ClanGetByEndpoint/GetByID`;
    if(this.isClan())
    {
      this.httpClient.get<LogiraniClan>(url).subscribe(x=>{
        this.logiraniClan = x.clanovi;
      })
    }

  }
  getRandomInt(min: number, max: number): number {
    min = Math.ceil(min);
    max = Math.floor(max);

    return Math.floor(Math.random() * (max - min + 1)) + min;
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
  isClan(){
    return this.dohvatiLogiranogKorisnika()?.autentifikacijaToken.korisnickiNalog.isClan;
  }
}
