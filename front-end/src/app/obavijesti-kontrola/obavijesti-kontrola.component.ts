import {Component, OnInit} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {NgForOf, NgIf} from "@angular/common";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {ObavijestSnimi} from "./obavijest-snimi";
import {Mojconfig} from "../moj-config";
import {Obavijesti, ObavijestiGetall} from "../obavijesti/obavijesti-getall";
import {OdabranaObavijest} from "./odabrana-obavijest";

@Component({
  selector: 'app-obavijesti-kontrola',
  standalone: true,
  imports: [
    FormsModule,
    NgIf,
    HttpClientModule,
    NgForOf
  ],
  templateUrl: './obavijesti-kontrola.component.html',
  styleUrl: './obavijesti-kontrola.component.css'
})
export class ObavijestiKontrolaComponent implements OnInit{

  public obavijest: ObavijestSnimi | null = null;
  public obavijesti:Obavijesti[]=[];
  public odabranaObavijest: OdabranaObavijest | null = null;
  constructor(public httpClient:HttpClient) {
  }
  trenutnoVrijeme = new Date();
  trenutnoVrijemeFormat = this.trenutnoVrijeme.toISOString();
  naslov:string = '';
  sadrzaj:string = '';
  slika:string = '';
  dodajIsVidljivo: boolean = false;
  public counter:number = 1;
  obrisiIsVidljivo: boolean = false;
  urediIsVidljivo: boolean = false;

  dodajVidljivo() {
    this.dodajIsVidljivo = !this.dodajIsVidljivo;
    this.urediIsVidljivo = false;
    this.obrisiIsVidljivo = false;
  }

  obrisiVidljivo() {
    this.obrisiIsVidljivo = !this.obrisiIsVidljivo;
    this.dodajIsVidljivo = false;
    this.urediIsVidljivo = false;
  }

  urediVidljivo() {
    this.urediIsVidljivo = !this.urediIsVidljivo;
    this.dodajIsVidljivo = false;
    this.obrisiIsVidljivo = false;
  }
  isprazniFormu() {
      this.naslov = '';
      this.sadrzaj = '';
      this.slika = '';
      this.dodajIsVidljivo = false;
  }

  dodajObavijest(obavijest: ObavijestSnimi) {
    // @ts-ignore
    this.obavijest = {
      datumObjave :this.trenutnoVrijemeFormat,
      naslov: this.naslov,
      text: this.sadrzaj,
      slika: this.slika,
    }
    let url = Mojconfig.adresa_servera + `/Obradi/ObavijestiDodajEndpoint`;
    this.httpClient.post(url,this.obavijest).subscribe(x=>{
      alert('Uspješno dodano, zbog bootstrapa u komponenti dodajte rucno jedan button. Uskoro ce bit popravljeno');
      window.location.reload();
    })
  }

  ngOnInit(): void {
    let url = Mojconfig.adresa_servera + `/Obradi/ObavijestiPretragaEndpoint`;
    this.httpClient.get<ObavijestiGetall>(url).subscribe((x:ObavijestiGetall)=>{
      this.obavijesti = x.obavijesti;
  });
  }


  obrisiObavijest(item: Obavijesti) {
    let id = item.id;
    let url = Mojconfig.adresa_servera + `/Obradi/ObavijestiObrisiEndpoint?ObavijestID=${id}`;
    this.httpClient.delete(url).subscribe((x)=>{
      alert('Uspjesno obrisana obavijest')
      window.location.reload()
    });
  }
  uredi(item: Obavijesti) {
    // @ts-ignore
    this.odabranaObavijest = {
      id: item.id,
      naslov: item.naslov,
      sadrzaj: item.text
    }
  }
  isprazniSadrzaj() {
    // @ts-ignore
    this.odabranaObavijest = {
      naslov: '',
      sadrzaj: ''
    }
    this.urediIsVidljivo = false;
  }
  izmeni() {
    let url = Mojconfig.adresa_servera + `/Obradi/ObavijestiUpdateEndpoint`;
    this.httpClient.post(url,this.odabranaObavijest).subscribe(x=>{
      alert('Uspjesna izmjena');
      window.location.reload()
    })
  }
}
