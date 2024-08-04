import { Component, OnInit } from '@angular/core';
import {Router, RouterLink} from "@angular/router";
import { ProizvodiGetAllResponse } from "./ProizvodiGetAllResponse";
import { Mojconfig } from "../app/moj-config";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { CommonModule, NgOptimizedImage } from "@angular/common";
import { SharedDataService } from "../app/shared-data-service";
import {IzdvojiPotvrdaComponent} from "./izdvoji-potvrda/izdvoji-potvrda.component";
import {FormsModule} from "@angular/forms";
import {UkloniProizvodComponent} from "./ukloni-proizvod/ukloni-proizvod.component";
import {KategorijaRequest, Kategorije, KategorijeR} from "./KategorijaResponse";
import {Brendovi, BrendR} from "./BrendResponse";
declare function porukaSuccess(m: string): any;
declare function porukaError(m: string): any;
interface Slika {
  putanja: string;
}
interface Product {
  naziv: string;
  opis: string;
  cijena: number;
  kategorija: { id: number; nazivKategorije: string; opis: string };
  kolicinaNaSkladistu: number;
  boja: string;
  brend: { brendId: number; nazivBrenda: string };
  velicina: string;
  datumObjave: string;
  slike: Slika[];
  popust: number;
  isIzdvojen: boolean;
}
@Component({
  selector: 'app-pmain',
  standalone: true,
  imports: [RouterLink, HttpClientModule, CommonModule, NgOptimizedImage, IzdvojiPotvrdaComponent, FormsModule, UkloniProizvodComponent],
  templateUrl: './pmain.component.html',
  styleUrl: './pmain.component.css'
})
export class PmainComponent implements OnInit {
  selectedBrend: { id: number; naziv: string } = {id: 0, naziv: ''};
  selectedKategorija: { kategorijaId: number; naziv: string; opis: string } = {kategorijaId: 0, naziv: '', opis: ''};
  inputValue: string = "";
  DodajProizvodOtvoren: boolean = false;
  Kategorije: Kategorije[]=[];
  Brendovi: Brendovi[]=[];
  product: Product = this.initializeProduct();
  isPotvrdaBrisanjaVidljiva: boolean = false;
  proizvodZaBrisanjeID: any;

  constructor(public httpClient: HttpClient, private sharedDataService: SharedDataService, private router: Router) {
    this.sharedDataService.selectedBrend$.subscribe((selectedBrend) => {
      this.selectedBrend = selectedBrend;
      this.sharedDataService.selectedKategorija$.subscribe((selectedKategorija) => {
        this.selectedKategorija = selectedKategorija;
        this.sharedDataService.inputValue$.subscribe((value) => {
          this.inputValue = value;
          this.GetProizvodi();
        });
      });
    });
  }

  ngOnInit(): void {
    console.log("test");
    this.GetProizvodi();
    this.getKategorije();
    this.getBrendovi();
  }

  proizvodi: ProizvodiGetAllResponse[] = [];

  getKategorije() {
    let url = Mojconfig.adresa_servera + "/Kategorija/Pretraga po nazivu";
    this.httpClient.get<KategorijeR>(url).subscribe(
      response => {
        this.Kategorije = response.kategorije;
        console.log("kategorije", this.Kategorije);
      },
      error => {
        console.log("Greska pri dohvacanju kategorija");
      }
    );
  }

  getBrendovi() {
    let url = Mojconfig.adresa_servera + "/Brend/GetAll";
    this.httpClient.get<BrendR>(url).subscribe(
      response => {
        this.Brendovi = response.brendovi;
        console.log("brendovi", this.Brendovi);
      },
      error => {
        console.log("Greska pri dohvacanju brendova");
      }
    );
  }

  GetProizvodi() {
    let url = Mojconfig.adresa_servera + "/api/products/GetProizvodi";
    this.httpClient.get<ProizvodiGetAllResponse[]>(url).subscribe(
      x => {
        this.proizvodi = x.filter(proizvod => {
          console.log(this.inputValue);
          const isBrendMatch = this.selectedBrend.naziv === "" || proizvod.brend.nazivBrenda === this.selectedBrend.naziv;
          const isKategorijaMatch = this.selectedKategorija.naziv === "" || proizvod.kategorija.id === this.selectedKategorija.kategorijaId;
          const isInputMatch = this.inputValue === "" ||
            (proizvod.naziv.toLowerCase().includes(this.inputValue.toLowerCase()) ||
              proizvod.opis.toLowerCase().includes(this.inputValue.toLowerCase()) ||
              proizvod.kategorija.nazivKategorije.toLowerCase().includes(this.inputValue.toLowerCase()) ||
              proizvod.brend.nazivBrenda.toLowerCase().includes(this.inputValue.toLowerCase())
            );
          return isBrendMatch && isKategorijaMatch && isInputMatch;
        });
      }
    );
  }

  protected readonly RouterLink = RouterLink;
  isPotvrdaVidljiva: boolean = false;

  otvaranjePotvrda($event:boolean){
    this.isPotvrdaVidljiva = $event;
  }

  IdiNaRutu(proizvodID: number) {
    this.router.navigate(['/viewproizvod', proizvodID]);
  }

  IDproizvod: any;

  pripremiProizvod(proizvod: ProizvodiGetAllResponse) {
    this.IDproizvod = proizvod.proizvodID;
  }

  OtvoriDodavanjeProizvoda() {
    this.DodajProizvodOtvoren = true;
  }

  initializeProduct(): Product {
    return {
      naziv: '',
      opis: '',
      cijena: 0,
      kategorija: { id: 0, nazivKategorije: '', opis: '' },
      kolicinaNaSkladistu: 0,
      boja: '',
      brend: { brendId: 0, nazivBrenda: '' },
      velicina: '',
      datumObjave: "2024-08-04T15:32:35.956Z",
      slike: [{ putanja: '' }],
      popust: 0,
      isIzdvojen: false
    };
  }

  addSlika() {
    this.product.slike.push({ putanja: '' });
  }

  removeSlika(index: number) {
    this.product.slike.splice(index, 1);
  }

  pripremiBrisanje(proizvodID: any) {
    this.proizvodZaBrisanjeID = proizvodID;
    this.isPotvrdaBrisanjaVidljiva = true;
  }

  otvorenjeBrisanja($event: boolean) {
    this.isPotvrdaVidljiva = $event;
  }

  dodajProizvod() {


    for (let br of this.Brendovi) {
      if(br.brendID == this.product.brend.brendId){
        this.product.brend.brendId=br.brendID;
        this.product.brend.nazivBrenda=br.naziv;
      }
    }
    for(let kt of this.Kategorije){
      if(kt.kategorijaId == this.product.kategorija.id){
        this.product.kategorija.id=kt.kategorijaId;
        this.product.kategorija.nazivKategorije=kt.naziv;
        this.product.kategorija.opis=kt.opis;
      }
    }
      console.log("NAKON PREUZIMANJA SA FOROVIMA: ", this.product.brend,this.product.kategorija);
    /*
    var novaKategorija = this.httpClient.get<Kategorije>(
      Mojconfig.adresa_servera + `/Kategorija/Pretraga po Id?Id=${this.product.kategorija.id}`
    ).subscribe(x => {
      this.product.kategorija.id = x.kategorijaId;
      this.product.kategorija.opis= x.opis;
      this.product.kategorija.nazivKategorije = x.naziv;
      console.log("ALO", this.product.kategorija);
    });

    this.httpClient.get<Brendovi>(
      Mojconfig.adresa_servera + `/Brend/Brend po Id?request=${this.product.brend.brendId}`
    ).subscribe(x => {
      this.product.brend.brendId = x.brendID;
      this.product.brend.nazivBrenda = x.naziv;
      console.log("ALO", this.product.brend);
    });
    */
    var body = {
      "naziv": this.product.naziv,
      "opis": this.product.opis,
      "cijena": this.product.cijena,
      "kategorija": {
        "id": this.product.kategorija.id,
        "nazivKategorije": this.product.kategorija.nazivKategorije,
        "opis": this.product.kategorija.opis
      },
      "kolicinaNaSkladistu": this.product.kolicinaNaSkladistu,
      "boja": this.product.boja,
      "brend": {
        "brendId": this.product.brend.brendId,
        "nazivBrenda": this.product.brend.nazivBrenda
      },
      "velicina": this.product.velicina,
      "datumObjave": "2024-08-04T15:32:35.956Z",
      "slike": this.product.slike,
      "popust": this.product.popust,
      "isIzdvojen": this.product.isIzdvojen
    };

    console.log("Nakon formiranja bodija: ",body);
    this.httpClient.post(Mojconfig.adresa_servera + "/api/products", body).subscribe(x => {
        this.DodajProizvodOtvoren = false;
        porukaSuccess(`Uspjesno dodan proizvod ${this.product.naziv}`);
        this.GetProizvodi();
      },
      error => {
        porukaError("Greska pri dodavanju proizvoda");
      }
    );
  }

  funkcija() {
    console.log("BREND", this.product.brend);
    console.log("KATEGORIJA", this.product.kategorija);
  }
}
