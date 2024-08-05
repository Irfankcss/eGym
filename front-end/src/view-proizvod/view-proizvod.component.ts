import {Component, OnInit} from '@angular/core';
import {PtopComponent} from "../ptop/ptop.component";
import {FormsModule} from "@angular/forms";
import {ActivatedRoute} from "@angular/router";
import {ProizvodGetByIDResponse} from "./ProizvodGetByIDResponse";
import {Mojconfig} from "../app/moj-config";
import {HttpClient,HttpClientModule} from "@angular/common/http";
import {CommonModule, DecimalPipe} from "@angular/common";
import {ProizvodiGetAllResponseSlika} from "../pmain/ProizvodiGetAllResponse";

declare function porukaSuccess(m:string):any;
declare function porukaError(m:string):any;

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
    korisnikString: string = "";
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
    this.korisnikString = window.localStorage.getItem("korisnik")??"";
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

    const korisnikObject = JSON.parse(this.korisnikString);
    const korisnikId = korisnikObject.autentifikacijaToken.korisnickiNalogId;

    if (this.korisnikString == "") {
      porukaError("Morate biti prijavljeni da biste mogli dodati proizvode u korpu");
      return;
    }
    if (this.kolicina < 1) {
      porukaError("Kolicina ne moze biti manja od 1");
      return;
    }
    this.httpClient.post(Mojconfig.adresa_servera + `/api/Korpa/DodajProizvodUKorpu?ProizvodID=${this.proizvodID}&KorisnikID=${korisnikId}&Kolicina=${this.kolicina}`, {})
      .subscribe(x => {
        if (this.kolicina == 1) {
          porukaSuccess(`Uspjesno ste dodali ${this.kolicina} "${this.proizvod.naziv}" u korpu`);
        } else {
          porukaSuccess(`Uspjesno ste dodali ` + this.kolicina + ` "${this.proizvod.naziv}" u korpu`);
        }

      });

  }

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
