import {Component, OnInit} from '@angular/core';
import {Router, RouterLink} from "@angular/router";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {AuthLoginRequest} from "./authLoginRequest";
import {FormsModule} from "@angular/forms";
import {Mojconfig} from "../moj-config";
import {AuthLoginResponse} from "./authLoginResponse";
import {withNoHttpTransferCache} from "@angular/platform-browser";

declare function porukaSuccess(m:string):any;
declare function porukaError(m:string):any;

@Component({
  selector: 'app-prijavi-se',
  standalone: true,
  imports: [
    RouterLink,
    HttpClientModule,
    FormsModule
  ],
  templateUrl: './prijavi-se.component.html',
  styleUrl: './prijavi-se.component.css'
})
export class PrijaviSeComponent implements OnInit{

  public loginRequest:AuthLoginRequest = {
    korisnickoIme:"",
    lozinka:""
  }
  constructor(public httpClient:HttpClient, private router:Router) {
  }
  ngOnInit(): void {
  }


  signIn() {
    let url = Mojconfig.adresa_servera + `/Obradi/AuthLoginEndpoint/login`;
    this.httpClient.post<AuthLoginResponse>(url,this.loginRequest).subscribe((x)=>{
      if(!x.isLogiran){
        porukaError("Pogrešan username/password");
        this.loginRequest.korisnickoIme = "";
        this.loginRequest.lozinka = "";
      }
      else{
        let token = x.autentifikacijaToken.vrijednost;
        window.localStorage.setItem("my-auth-token",token);
        window.localStorage.setItem("korisnik",JSON.stringify(x));
        porukaSuccess("Uspješna prijava");
        this.router.navigate(["/obavijesti"]);
      }
    })
  }
}
