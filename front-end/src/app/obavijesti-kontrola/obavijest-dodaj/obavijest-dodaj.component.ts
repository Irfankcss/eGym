import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Mojconfig} from "../../moj-config";
import {FormsModule} from "@angular/forms";
import {ObavijestiComponent} from "../../obavijesti/obavijesti.component";
import {Obavijesti, ObavijestiGetall} from "../../obavijesti/obavijesti-getall";

declare function porukaSuccess(m:string):any;
declare function porukaError(m:string):any;

declare function sakrijDugme():any;
declare function prikaziDugme():any;

@Component({
  selector: 'app-obavijest-dodaj',
  standalone: true,
  imports: [
    HttpClientModule,
    FormsModule
  ],
  templateUrl: './obavijest-dodaj.component.html',
  styleUrl: './obavijest-dodaj.component.css'
})
export class ObavijestDodajComponent implements OnInit{

  @Output() otvori = new EventEmitter<boolean>();
    ngNaslov:any;
    ngSadrzaj:any;
    ngSlika:any;

    prikaz:boolean = true;

    obavijesti:Obavijesti[]=[];

    constructor(public httpClient:HttpClient) {
    }

  ngOnInit(): void {
  }
  dodajNovuObavijest() {
    let url = Mojconfig.adresa_servera + '/Obradi/ObavijestiDodajEndpoint';
    let requestBody = {
      "datumObjave": new Date(),
      "naslov": this.ngNaslov,
      "text": this.ngSadrzaj,
      "slika": this.ngSlika,
    }
    if(requestBody.naslov == null || requestBody.text  == null || requestBody.slika == null) {
      porukaError("Sva polja su obavezna");
    }
    else{
      this.httpClient.post(url,requestBody).subscribe(x=>{
        this.zatvori();
        this.prikaziObavijesti();
        window.location.reload();
      })
    }
  }

  zatvori() {
    this.prikaz = !this.prikaz;
    this.otvori.emit(this.prikaz);
  }
  prikaziObavijesti(){
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
}
