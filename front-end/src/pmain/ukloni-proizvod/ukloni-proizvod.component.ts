import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { Router } from "@angular/router";
import { Mojconfig } from "../../app/moj-config";

declare function porukaSuccess(m: string): any;
declare function porukaError(m: string): any;

@Component({
  selector: 'app-ukloni-proizvod',
  standalone: true,
  imports: [
    FormsModule,
    HttpClientModule
  ],
  templateUrl: './ukloni-proizvod.component.html',
  styleUrls: ['./ukloni-proizvod.component.css']
})
export class UkloniProizvodComponent {

  @Output() otvori = new EventEmitter<boolean>();

  prikaz: boolean = true;

  constructor(public httpClient: HttpClient, private router: Router) { }

  zatvori() {
    this.prikaz = false;
    this.otvori.emit(this.prikaz);
  }

  @Input() proizvodID: any;

  obrisiProizvod() {
    let proizvodID = this.proizvodID;
    let url = Mojconfig.adresa_servera + `/api/products/DeleteProizvod/${proizvodID}`;

    this.httpClient.delete(url, { responseType: 'text' }).subscribe(response => {
      this.zatvori();
      this.router.navigate(['/obavijesti']);
      porukaSuccess(response);
    }, error => {
      porukaError('Greška prilikom brisanja proizvoda');
    });
  }
}
