import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CommonModule,NgFor,NgIf} from "@angular/common";
import {Mojconfig} from "../moj-config";

@Component({
  selector: 'app-narudzbeall',
  standalone: true,
  imports: [CommonModule,NgFor,NgIf],
  templateUrl: './narudzbeall.component.html',
  styleUrl: './narudzbeall.component.css'
})
export class NarudzbeallComponent implements OnInit{
  narudzbe:any = [];
  loading: boolean = true;
  naslov:string="Narudžbe za pregled:"
  constructor(private httpClient: HttpClient) {
  }

  ngOnInit() {
    this.getNarudzbe();

  }

  private getNarudzbe() {
    this.httpClient.get(Mojconfig.adresa_servera+"/Narudzba2/NarudzbaGetAll").subscribe(x=>{
        this.narudzbe = x;
        this.loading = false;
      },
      error => {
        console.log("Greska u preuzimanju narudzbi sa servera");
        this.loading = false;
      })
  }

  protected readonly Date = Date;

  prihvaceneSwitched() {
    this.httpClient.get(Mojconfig.adresa_servera + "/Narudzba2/NarudzbaGetAll").subscribe(
      (x: any) => {
        this.narudzbe = x.filter((n: { isOdobrena: boolean }) => n.isOdobrena === true);
        this.loading = false;
      },
      error => {
        console.log("Greska u preuzimanju narudzbi sa servera");
        this.loading = false;
      }
    );
    this.naslov="Odobrene Narudžbe:"
  }

  zaPregledSwitched() {
    this.httpClient.get(Mojconfig.adresa_servera + "/Narudzba2/NarudzbaGetAll").subscribe(
      (x: any) => {
        this.narudzbe = x.filter((n: { isOdobrena: boolean }) => n.isOdobrena === false);
        this.loading = false;
      },
      error => {
        console.log("Greska u preuzimanju narudzbi sa servera");
        this.loading = false;
      }
    );
    this.naslov="Narudžbe za pregled:"
  }
}
