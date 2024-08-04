import { Component, OnInit } from '@angular/core';
import {Router, RouterLink} from "@angular/router";
import { ProizvodiGetAllResponse } from "./ProizvodiGetAllResponse";
import { Mojconfig } from "../app/moj-config";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { CommonModule, NgOptimizedImage } from "@angular/common";
import { SharedDataService } from "../app/shared-data-service";
import {IzdvojiPotvrdaComponent} from "./izdvoji-potvrda/izdvoji-potvrda.component";
import {FormsModule} from "@angular/forms";
import {KategorijaGetAllResponse} from "../pleft/KategorijaGetAllResponse";
import {BrendGetAllResponse} from "../pleft/BrendGetAllResponse";
import {UkloniProizvodComponent} from "./ukloni-proizvod/ukloni-proizvod.component";
import {KategorijeR} from "./KategorijaResponse";
import {BrendR} from "./BrendResponse";

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
  Kategorije: any;
  Brendovi: any;
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

   getKategorije () {
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
        this.proizvodi = x.filter(proizvod => {console.log(this.inputValue);
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

  IDproizvod:any;

  pripremiProizvod(proizvod: ProizvodiGetAllResponse) {
    this.IDproizvod=proizvod.proizvodID;
  }

  OtvoriDodavanjeProizvoda() {
    this.getKategorije();
    this.getBrendovi();
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
      datumObjave: new Date().toISOString().slice(0, -1),
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

  DodajProizvod() {
    console.log(this.product);
  }
}
