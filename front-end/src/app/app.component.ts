import {Component, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import {Router, RouterLink, RouterOutlet} from '@angular/router';
import {FormsModule} from "@angular/forms";
import {Mojconfig} from "./moj-config";
import {HttpClient, HttpClientModule} from "@angular/common/http";

declare function porukaSuccess(m:string):any;

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, FormsModule, RouterLink,HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'front-end';

  constructor(private httpClient:HttpClient,private router:Router) {
  }
  jelLogiran():boolean{
    let token = window.localStorage.getItem("my-auth-token");

    return token != "";
  }
  logout() {
    let token = window.localStorage.getItem("my-auth-token")??"";
    let korisnik = window.localStorage.getItem("korisnik")??"";
    window.localStorage.setItem("my-auth-token","");
    window.localStorage.setItem("korisnik","");

    let url = Mojconfig.adresa_servera + `/Obradi/AuthLogoutEndpoint/logout`;
    this.httpClient.post(url,{},{
      headers:{
        "my-auth-token":token
      }
    }).subscribe(x=>{
      porukaSuccess("Uspješan logout");
      this.router.navigate(["/prijavi-se"]);
    })

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
  isAdmin(){
    return this.dohvatiLogiranogKorisnika()?.autentifikacijaToken.korisnickiNalog.isAdmin;
  }
}
