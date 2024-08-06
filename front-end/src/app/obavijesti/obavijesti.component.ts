import {AfterViewInit, Component, ElementRef, OnInit, QueryList, Renderer2, ViewChild} from '@angular/core';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Obavijesti, ObavijestiGetall} from "./obavijesti-getall";
import {Mojconfig} from "../moj-config";
import {NgForOf, NgIf} from "@angular/common";
import {ObavijestiKontrolaComponent} from "../obavijesti-kontrola/obavijesti-kontrola.component";
import {ContactFooterComponent} from "../contact-footer/contact-footer.component";
import {IzdvojeniProizvodiComponent} from "../izdvojeni-proizvodi/izdvojeni-proizvodi.component";

declare function sakrijDugme():any;
declare function prikaziDugme():any;

@Component({
  selector: 'app-obavijesti',
  standalone: true,
  imports: [HttpClientModule, NgForOf, ObavijestiKontrolaComponent, ContactFooterComponent, IzdvojeniProizvodiComponent, NgIf],
  templateUrl: './obavijesti.component.html',
  styleUrl: './obavijesti.component.css'
})
export class ObavijestiComponent implements OnInit{
  constructor(public httpClient: HttpClient) {

  }
  obavijesti:Obavijesti[]=[];
  public slideIndex = 0;
  ngOnInit(): void {
    let url = Mojconfig.adresa_servera + `/Obradi/ObavijestiPretragaEndpoint`;
    this.httpClient.get<ObavijestiGetall>(url).subscribe((x:ObavijestiGetall)=>{
      this.obavijesti = x.obavijesti;
      if(this.obavijesti.length < 3){
          sakrijDugme();
      }else if(this.obavijesti.length == 3){
          prikaziDugme();
      }
    })

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
