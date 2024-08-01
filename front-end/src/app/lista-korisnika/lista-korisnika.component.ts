import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Mojconfig} from "../moj-config";
import {NgForOf, NgIf} from "@angular/common";
import {ObavijestiGetall} from "../obavijesti/obavijesti-getall";
import {Korisnci} from "./korisnci";
import {UrediKorisnikComponent} from "./uredi-korisnik/uredi-korisnik.component";

declare function porukaSuccess(m:string):any;

@Component({
  selector: 'app-lista-korisnika',
  standalone: true,
  imports: [HttpClientModule, NgForOf, NgIf, UrediKorisnikComponent],
  templateUrl: './lista-korisnika.component.html',
  styleUrl: './lista-korisnika.component.css'
})
export class ListaKorisnikaComponent implements OnInit{

  public listaKorisnika:any;
  constructor(public httpClient:HttpClient) {
  }
  ngOnInit(): void {
    let url = Mojconfig.adresa_servera + `/Obradi/KorisnickiNalogPretragaEndpoint`;
    this.httpClient.get<Korisnci>(url).subscribe((x:Korisnci)=>{
      this.listaKorisnika = x.korisnickiNalozi;
      //console.log(this.listaKorisnika);
    })
  }

  odaberi(lk: any) {
    let korisnikID = lk.id;
    let url = Mojconfig.adresa_servera + `/Obradi/KorisnickiNalogObrisiEndpoint?KorisnickiNalogID=${korisnikID}`;
    this.httpClient.delete(url).subscribe(x=>{
      porukaSuccess("Uspješno obrisan korisnik");
      this.ngOnInit();
    })
  }

  protected readonly porukaSuccess = porukaSuccess;

  isUrediVidljivo: boolean = false;
  prikaziEdit = false;

  KorisnickoIme:any;
  IsAdmin:any;
  IsRadnik:any;
  IsKorisnik:any;
  ID:any;
  pripremiKorisnika(lk: any) {
      this.ID  = lk.id
      this.KorisnickoIme = lk.korisnickoIme;
      this.IsAdmin = lk.isAdmin;
      this.IsRadnik = lk.isRadnik;
      this.IsKorisnik = lk.isKorisnik;
  }
  otvaranjeEdit($event : boolean)
  {
    this.isUrediVidljivo = $event;
  }
}
