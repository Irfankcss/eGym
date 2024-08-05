import {Component, OnInit} from '@angular/core';
import {EvidencijaDolazaka} from "./evidencija-dolazaka";
import {NgForOf} from "@angular/common";
import {Mojconfig} from "../../moj-config";
import {HttpClient, HttpClientModule} from "@angular/common/http";

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
      this.evidencija.push({redniBroj: i, datum: new Date(izracunatiDatum.getFullYear(),izracunatiDatum.getMonth(),izracunatiDatum.getDay(),izracunatiDatum.getHours(),izracunatiDatum.getMinutes(),izracunatiDatum.getSeconds()), vrijemeIzlaska: randomNumber, vrijemeUlaska: randomNumber})

      this.evidencija.sort((a, b) => a.datum.getTime() - b.datum.getTime());

    }

  }
  getRandomInt(min: number, max: number): number {
    min = Math.ceil(min);
    max = Math.floor(max);

    return Math.floor(Math.random() * (max - min + 1)) + min;
  }
}
