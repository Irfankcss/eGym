import {Component, OnInit} from '@angular/core';
import {Mojconfig} from "../moj-config";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {NgForOf, NgIf} from "@angular/common";
import {UkloniPotvrdaComponent} from "./ukloni-potvrda/ukloni-potvrda.component";
import {Router} from "@angular/router";



@Component({
  selector: 'app-izdvojeni-proizvodi',
  standalone: true,
  imports: [
    HttpClientModule,
    NgForOf,
    UkloniPotvrdaComponent,
    NgIf
  ],
  templateUrl: './izdvojeni-proizvodi.component.html',
  styleUrl: './izdvojeni-proizvodi.component.css'
})
export class IzdvojeniProizvodiComponent implements OnInit{

  public izdvojeniProizovdi:any;
  ukloniIsVidljivo: boolean = false;
  proizvodID:any;

  constructor(public httpClient:HttpClient, private router:Router) {
  }
  ngOnInit(): void {
      let url = Mojconfig.adresa_servera + `/api/products/GetIzdvojeniProizvodi`;

      this.httpClient.get<any>(url).subscribe(x=>{
        this.izdvojeniProizovdi=x;
      })
  }
  otvaranjePotvrda($event:boolean){
    this.ukloniIsVidljivo = $event;
  }

  pripremiProizvod(ip: any) {
    this.proizvodID = ip.id;
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

  IdinaProizvod(id:number) {
    this.router.navigate(['/viewproizvod', id]);
  }
}
