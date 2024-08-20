import {Component, OnInit} from '@angular/core';
import {NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {timeoutProvider} from "rxjs/internal/scheduler/timeoutProvider";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Router, RouterLink} from "@angular/router";
import {Mojconfig} from "../moj-config";
import {ClanarinaKorisnikComponent} from "./clanarina-korisnik/clanarina-korisnik.component";
import {ClanarinaRadnikComponent} from "./clanarina-radnik/clanarina-radnik.component";

@Component({
  selector: 'app-clanarina',
  standalone: true,
  imports: [
    NgIf,
    FormsModule,
    HttpClientModule,
    ClanarinaKorisnikComponent,
    ClanarinaRadnikComponent
  ],
  templateUrl: './clanarina.component.html',
  styleUrl: './clanarina.component.css'
})
export class ClanarinaComponent implements OnInit{

  constructor(public httpClient:HttpClient, private router:Router) {
  }
  jelLogiran():boolean{
    let token = window.localStorage.getItem("my-auth-token");

    return token != "";
  }
  uclaniSe() {
    var tipMjesecne = document.getElementById("tipMjesecne") as HTMLSelectElement;

    if(!this.jelLogiran()){
      this.router.navigate(["/prijavi-se"]);
    }
    else{
      if(tipMjesecne.value == ""){
        tipMjesecne.style.border = "3px solid red";
      }
      else{
        let url = Mojconfig.adresa_servera + `/Clan/Dodaj`;
        let requestBody = {
          "vrsta": tipMjesecne.value
        }
        this.httpClient.post(url,requestBody).subscribe(x=>{
          let korisnik = localStorage.getItem("korisnik")??"";
          let korisnikParse = JSON.parse(korisnik);
          korisnikParse.autentifikacijaToken.korisnickiNalog.isClan = true;
          korisnik = JSON.stringify(korisnikParse);
          localStorage.setItem("korisnik",korisnik);
          window.location.reload();
        })
      }
    }





  }

  ngOnInit(): void {
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
  isRadnik(){
    return this.dohvatiLogiranogKorisnika()?.autentifikacijaToken.korisnickiNalog.isRadnik;
  }
  isAdmin(){
    return this.dohvatiLogiranogKorisnika()?.autentifikacijaToken.korisnickiNalog.isAdmin;
  }
}
