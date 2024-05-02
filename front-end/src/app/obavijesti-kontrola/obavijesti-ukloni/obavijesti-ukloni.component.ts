import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Mojconfig} from "../../moj-config";
import {ObavijestiGetall} from "../../obavijesti/obavijesti-getall";
import {NgForOf, NgIf} from "@angular/common";
import {OdabranaObavijest} from "../obavijesti-uredi/odabrana-obavijest";
declare function porukaSuccess(m:string):any;

@Component({
  selector: 'app-obavijesti-ukloni',
  standalone: true,
  imports: [
    FormsModule,
    HttpClientModule,
    NgForOf,
    NgIf
  ],
  templateUrl: './obavijesti-ukloni.component.html',
  styleUrl: './obavijesti-ukloni.component.css'
})
export class ObavijestiUkloniComponent implements OnInit{

    @Output() otvori = new EventEmitter<boolean>();

    prikaz:boolean = true;

    public obavijesti:any;
    potvrdiIsVidljivo: boolean = false;
    public odabranaObavijest:OdabranaObavijest | null = null;
    isObavijestiVidljive: boolean = true;
    isNaslovPotvrdeVidljiv: boolean = false;
    constructor(public httpClient:HttpClient) {
    }
    ngOnInit(): void {
      let url = Mojconfig.adresa_servera + `/Obradi/ObavijestiPretragaEndpoint`;
      this.httpClient.get<ObavijestiGetall>(url).subscribe((x:ObavijestiGetall)=>{
        this.obavijesti = x.obavijesti;
      })
    }

  ukloniObavijest(o: any) {
      // @ts-ignore
    this.odabranaObavijest = {
      id:o.id,
      naslov:o.naslov,
      sadrzaj:o.text,
      slika:o.slika
      };
  }

  obrisiObavijest() {
      let id = this.odabranaObavijest?.id;
      let url = Mojconfig.adresa_servera + `/Obradi/ObavijestiObrisiEndpoint?ObavijestID=${id}`;
      this.httpClient.delete(url).subscribe(x=>{
        this.zatvori();
        window.location.reload();
      });
  }

  zatvori() {
      this.prikaz = !this.prikaz;
      this.otvori.emit(this.prikaz);
  }
}
