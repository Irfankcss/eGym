import { Component, OnInit } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { KategorijaGetAllResponse } from './KategorijaGetAllResponse';
import { Mojconfig } from "../moj-config";
import { BrendGetAllResponse } from "./BrendGetAllResponse";
import { SharedDataService } from "../shared-data-service";

@Component({
  selector: 'app-pleft',
  templateUrl: './pleft.component.html',
  styleUrls: ['./pleft.component.css'],
  standalone: true,
  imports: [CommonModule, HttpClientModule],
})
export class PleftComponent implements OnInit {
  filteriPrikazani: boolean = true;
  prikazaneKategorije: boolean;
  prikazaniBrendovi: boolean;
  isKategorijeHovered: boolean = false;
  isBrendoviHovered: boolean = false;
  selectedBrend: { id: number, naziv: string } = { id: 0, naziv: '' };
  selectedKategorija: { kategorijaId: number, naziv: string, opis: string } = { kategorijaId: 0, naziv: '', opis: '' };

  constructor(public httpClient: HttpClient, private sharedDataService: SharedDataService) {
    this.filteriPrikazani = true;
    this.prikazaneKategorije = false;
    this.prikazaniBrendovi = false;
  }

  ngOnInit(): void {
  }

  kategorije: KategorijaGetAllResponse[] = [];
  brendovi: BrendGetAllResponse[] = [];

  GetKategorije() {
    let url = Mojconfig.adresa_servera + "/Kategorija/Pretraga po nazivu";
    this.httpClient.get<{ kategorije: KategorijaGetAllResponse[] }>(url).subscribe(
      response => {
        this.kategorije = response.kategorije;
      }
    );
  }

  GetBrendove() {
    let url = Mojconfig.adresa_servera + "/Brend/GetAll";
    this.httpClient.get(url).subscribe(
      response => {
        // @ts-ignore
        this.brendovi = response.brendovi;
      }
    );
  }

  prikaziFiltere() {
    this.filteriPrikazani = !this.filteriPrikazani;
  }

  prikaziKategorije() {
    this.prikazaneKategorije = !this.prikazaneKategorije;
    if (this.prikazaneKategorije) {
      this.GetKategorije();
    } else {
      this.kategorije = [];
    }
  }

  onKategorijeMouseEnter() {
    this.isKategorijeHovered = true;
  }

  onKategorijeMouseLeave() {
    this.isKategorijeHovered = false;
  }

  prikaziBrendove() {
    this.prikazaniBrendovi = !this.prikazaniBrendovi;
    if (this.prikazaniBrendovi) {
      this.GetBrendove();
    } else {
      this.brendovi = [];
    }
  }

  onBrendoviMouseEnter() {
    this.isBrendoviHovered = true;
  }

  onBrendoviMouseLeave() {
    this.isBrendoviHovered = false;
  }

  odabranBrend(event: any, brend: BrendGetAllResponse) {
    const isSelected = this.isSelectedBrend(brend);

    if (isSelected) {
      this.selectedBrend = { id: 0, naziv: '' };
    } else {
      this.selectedBrend = { id: brend.id, naziv: brend.naziv };
    }

    this.sharedDataService.updateSelectedBrend(this.selectedBrend);
  }

  odabranaKategorija($event: MouseEvent, kategorija: KategorijaGetAllResponse) {
    if (this.isSelected(kategorija)) {
      this.selectedKategorija = { kategorijaId: 0, naziv: '', opis: '' };
    } else {
      this.selectedKategorija = { kategorijaId: kategorija.kategorijaId, naziv: kategorija.naziv, opis: kategorija.opis };
    }    this.sharedDataService.updateSelectedKategorija(this.selectedKategorija);

  }

  isSelected(kategorija: KategorijaGetAllResponse): boolean {
    return this.selectedKategorija !== null && this.selectedKategorija.kategorijaId === kategorija.kategorijaId;
  }

  isSelectedBrend(brend: BrendGetAllResponse): boolean {
    return this.selectedBrend.naziv === brend.naziv;
  }
}
