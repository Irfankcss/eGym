import {Component, OnInit} from '@angular/core';
import {Mojconfig} from "../moj-config";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {NgForOf, NgIf} from "@angular/common";
import {UkloniPotvrdaComponent} from "./ukloni-potvrda/ukloni-potvrda.component";

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

  constructor(public httpClient:HttpClient) {
  }
  ngOnInit(): void {
      let url = Mojconfig.adresa_servera + `/api/products/GetIzdvojeniProizvodi`;

      this.httpClient.get<any>(url).subscribe(x=>{
        this.izdvojeniProizovdi=x;
        console.log(this.izdvojeniProizovdi);
      })
  }
  otvaranjePotvrda($event:boolean){
    this.ukloniIsVidljivo = $event;
  }

  pripremiProizvod(ip: any) {
    let proizvodID = ip.id;
  }
}
