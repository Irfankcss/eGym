import {Component, OnInit} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Mojconfig} from "../../moj-config";
import {ObavijestiGetall} from "../../obavijesti/obavijesti-getall";
import {NgForOf, NgIf} from "@angular/common";
import {OdabranaObavijest} from "./odabrana-obavijest";

@Component({
  selector: 'app-obavijesti-uredi',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    HttpClientModule,
    NgForOf,
    NgIf,
    FormsModule
  ],
  templateUrl: './obavijesti-uredi.component.html',
  styleUrl: './obavijesti-uredi.component.css'
})
export class ObavijestiUrediComponent implements OnInit{
    public obavijesti:any;
    spasiVidljivo: boolean = false;
    IsVidljivFormular: boolean = false;
    IsTabelaVidljivo: boolean = true;

    public odabranaObavijest:OdabranaObavijest | null = null;

    id:number = 0;
    ngNaslov: string = '';
    ngSadrzaj: any;
    ngSlika: any;

    constructor(public httpClient:HttpClient) {
    }

  ngOnInit(): void {
    let url = Mojconfig.adresa_servera + `/Obradi/ObavijestiPretragaEndpoint`;
    this.httpClient.get<ObavijestiGetall>(url).subscribe((x:ObavijestiGetall)=>{
      this.obavijesti = x.obavijesti;
    })
    }

  pripremiObavijest(o: any) {
      this.id = o.id;
    this.ngNaslov = o.naslov;
    this.ngSadrzaj = o.text;
    this.ngSlika = o.slika;
  }

  spasiIzmjene() {
    let url = Mojconfig.adresa_servera + `/Obradi/ObavijestiUpdateEndpoint`;
    this.odabranaObavijest = {
      id: this.id,
      naslov: this.ngNaslov,
      sadrzaj: this.ngSadrzaj,
      slika:this.ngSlika
    };

    this.httpClient.post(url,this.odabranaObavijest).subscribe(x=>{
      alert('Uspjesno izvrsena izmjena');
    });
  }
}
