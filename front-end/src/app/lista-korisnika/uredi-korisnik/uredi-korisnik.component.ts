import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {OdabranaObavijest} from "../../obavijesti-kontrola/obavijesti-uredi/odabrana-obavijest";
import {Mojconfig} from "../../moj-config";
import {Korisnci} from "../korisnci";

@Component({
  selector: 'app-uredi-korisnik',
  standalone: true,
  imports: [
    NgForOf,
    NgIf,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  templateUrl: './uredi-korisnik.component.html',
  styleUrl: './uredi-korisnik.component.css'
})
export class UrediKorisnikComponent implements OnInit{

  dodatniPodaciKorisnik:any;
  trenutniDatum: Date = new Date();

  constructor(public httpClient:HttpClient) {
  }
  ngOnInit(): void {
    let korisnikDodatniPodaciUrl = Mojconfig.adresa_servera + `/Obradi/KorisnikGetByIDEndpoint?ID=${this.ID}`;
    this.httpClient.get(korisnikDodatniPodaciUrl).subscribe(x=>{
      this.dodatniPodaciKorisnik = x;
    })
  }
  @Input() KorisnickoIme:any;
  @Input() IsAdmin:any;
  @Input() IsClan:any;
  @Input() IsRadnik:any;
  @Input() IsKorisnik:any;
  @Input() ID:any;
  @Output() otvori = new EventEmitter<boolean>();

  prikaz:boolean = true;
  zatvori()
  {
    this.prikaz = !this.prikaz;
    this.otvori.emit(this.prikaz);
  }

  spasiIzmjene() {
    let url = Mojconfig.adresa_servera + `/Obradi/KorisnickiNalogUpdateEndpoint`;
    let requestBody = {
      "korisnickiNalogID": this.ID,
      "isRadnik": this.IsRadnik,
      "isKorisnik": this.IsKorisnik
    }

    this.httpClient.post(url,requestBody).subscribe(x=>{
      this.zatvori();
      window.location.reload();
    })

    if(this.IsClan && this.IsRadnik){
      let obrisiClanUrl = Mojconfig.adresa_servera + `/Obradi/ClanObrisiIzmjenaStatusEndpoint?KorisnikID=${this.ID}`
      this.httpClient.delete(obrisiClanUrl).subscribe(x=>{
      })
      let izmjeniStatusUrl = Mojconfig.adresa_servera + `/Obradi/ClanIzmjeniStatusEndpoint?ClanID=${this.ID}`
      this.httpClient.post(izmjeniStatusUrl,{}).subscribe(x=>{
      })
    }
    if(this.IsRadnik){
      this.dodajRadnikaUbazu();
    }
  }
    dodajRadnikaUbazu(){
      let radnikUrl = Mojconfig.adresa_servera + `/Obradi/RadnikDodajEndpoint`;
      let requestBody = {
        "ime": this.dodatniPodaciKorisnik.ime,
        "prezime": this.dodatniPodaciKorisnik.prezime,
        "datumRodjenja": this.dodatniPodaciKorisnik.datumRodjenja,
        "brojTelefona": this.dodatniPodaciKorisnik.brojTelefona,
        "datumZaposlenja": this.trenutniDatum,
        "gradID": 1,
        "spol": this.dodatniPodaciKorisnik.spol,
        "korisnikID": this.ID
      }
      this.httpClient.post(radnikUrl,requestBody).subscribe(x=>{

      })
    }
}
