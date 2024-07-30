import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Mojconfig} from "../moj-config";
import {NgForOf, NgIf} from "@angular/common";
import {ObavijestiGetall} from "../obavijesti/obavijesti-getall";
import {Korisnci} from "./korisnci";

declare function porukaSuccess(m:string):any;

@Component({
  selector: 'app-lista-korisnika',
  standalone: true,
  imports: [HttpClientModule, NgForOf, NgIf],
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
}
