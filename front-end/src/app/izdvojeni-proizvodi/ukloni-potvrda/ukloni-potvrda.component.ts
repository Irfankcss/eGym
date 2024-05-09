import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Mojconfig} from "../../moj-config";
import {HttpClient, HttpClientModule} from "@angular/common/http";

@Component({
  selector: 'app-ukloni-potvrda',
  standalone: true,
  imports: [
    HttpClientModule
  ],
  templateUrl: './ukloni-potvrda.component.html',
  styleUrl: './ukloni-potvrda.component.css'
})
export class UkloniPotvrdaComponent {

  @Input() proizvodID:any;
  @Output() otvori = new EventEmitter<boolean>();

  prikaz:boolean = true;
  public izdvojeniProizovdi:any;

  constructor(public httpClient:HttpClient) {
  }

  zatvori() {
    this.prikaz = !this.prikaz;
    this.otvori.emit(this.prikaz);
  }

  ukloniProizvod() {
    let proizvodID = this.proizvodID;

    let url = Mojconfig.adresa_servera + `/Obradi/ProizvodiStatusUpdateOFFEndpoint?ProizvodID=${proizvodID}`;

    this.httpClient.post(url,{}).subscribe(x=>{
        this.zatvori();
        window.location.reload();
    })
  }
}
