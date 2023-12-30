import {Component, OnInit} from '@angular/core';
import {PtopComponent} from "../ptop/ptop.component";
import {FormsModule} from "@angular/forms";
import {ActivatedRoute} from "@angular/router";
import {ProizvodGetByIDResponse} from "./ProizvodGetByIDResponse";
import {Mojconfig} from "../app/moj-config";
import {HttpClient,HttpClientModule} from "@angular/common/http";
import {CommonModule, DecimalPipe} from "@angular/common";
import {ProizvodiGetAllResponseSlika} from "../pmain/ProizvodiGetAllResponse";

@Component({
  selector: 'app-view-proizvod',
  standalone: true,
  imports: [
    CommonModule,
    PtopComponent,
    FormsModule,
    HttpClientModule,
    DecimalPipe
  ],
  templateUrl: './view-proizvod.component.html',
  styleUrls: ['./view-proizvod.component.css'],
  providers: [
    HttpClient
  ]
})
export class ViewProizvodComponent  implements OnInit{
    kolicina: number = 1;
    proizvodID: number = 0;
    slikeproizvoda:ProizvodiGetAllResponseSlika[]=[];
    prikazanaSlika:number=0;
    proizvod:ProizvodGetByIDResponse = {
    proizvodID: 0,
    naziv: "",
    opis: "",
    cijena: 0,
    kolicinaNaSkladistu: 0,
    boja: "",
    brend: {
      brendId: 0,
      nazivBrenda: ""
    },
    velicina: "",
    datumObjave: "",
    slike: [],
    popust: 0,
    isIzdvojen: false
  };
  constructor(private route: ActivatedRoute, public httpClient: HttpClient) {}
  ngOnInit(): void {
    this.proizvodID = Number(this.route.snapshot.paramMap.get('proizvodID'));
    this.getProizvod();
  }
  uvecaj() {
    this.kolicina++;
  }

  umanji() {
    if (this.kolicina > 1) {
      this.kolicina--;
    }
  }

  onInputChange() {
    if(this.kolicina < 1) {
      this.kolicina = 1;
    }
  }

  dodajuKorpu() {
    if(this.kolicina==1){
      alert("Uspjesno ste dodali 1 proizvod u korpu");
    }else{
    alert("Uspjesno ste dodali " + this.kolicina + " proizvoda u korpu");
  }}

  async getProizvod(): Promise<void> {
    let url = Mojconfig.adresa_servera + "/api/products/GetProizvodByID?proizvodId=" + this.proizvodID;

       this.httpClient.get<ProizvodGetByIDResponse>(url).subscribe(
      x => {
        this.proizvod = x;
        this.slikeproizvoda = x.slike;
      }
    );
  }

  iducaSlika() {
    if (this.prikazanaSlika < this.slikeproizvoda.length - 1) {
      this.prikazanaSlika++;
    } else {
      this.prikazanaSlika = 0;
    }
    console.log(this.prikazanaSlika);
    console.log(this.slikeproizvoda.length);
  }

  prethodnaSlika() {
    if (this.prikazanaSlika > 0) {
      this.prikazanaSlika--;
    } else {
      this.prikazanaSlika = this.slikeproizvoda.length - 1;
    }
    console.log(this.prikazanaSlika);
    console.log(this.slikeproizvoda.length);
  }

}
