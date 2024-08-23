import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Mojconfig} from "../moj-config";
import {NgForOf, NgIf} from "@angular/common";
import {ObavijestiGetall} from "../obavijesti/obavijesti-getall";
import {Korisnci} from "./korisnci";
import {UrediKorisnikComponent} from "./uredi-korisnik/uredi-korisnik.component";
import {Router} from "@angular/router";

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
  constructor(public httpClient:HttpClient,private router:Router) {
  }
  ngOnInit(): void {
    if(!this.isAdmin()){
      this.router.navigate(["/obavijesti"])
    }
    let url = Mojconfig.adresa_servera + `/Obradi/KorisnickiNalogPretragaEndpoint`;
    this.httpClient.get<Korisnci>(url).subscribe((x:Korisnci)=>{
      this.listaKorisnika = x.korisnickiNalozi;
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
  IsClan:any;
  ID:any;
  pripremiKorisnika(lk: any) {
      this.ID  = lk.id
      this.KorisnickoIme = lk.korisnickoIme;
      this.IsAdmin = lk.isAdmin;
      this.IsRadnik = lk.isRadnik;
      this.IsKorisnik = lk.isKorisnik;
      this.IsClan = lk.isClan;
  }
  otvaranjeEdit($event : boolean)
  {
    this.isUrediVidljivo = $event;
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
  isAdmin(){
    return this.dohvatiLogiranogKorisnika()?.autentifikacijaToken.korisnickiNalog.isAdmin;
  }
}
