import { Component, OnInit } from '@angular/core';
import { ProizvodViewComponent } from "../proizvod-view/proizvod-view.component";
import { RouterLink } from "@angular/router";
import { ProizvodiGetAllResponse } from "./ProizvodiGetAllResponse";
import { Mojconfig } from "../app/moj-config";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { CommonModule, NgOptimizedImage } from "@angular/common";
import { SharedDataService } from "../app/shared-data-service";

@Component({
  selector: 'app-pmain',
  standalone: true,
  imports: [ProizvodViewComponent, RouterLink, HttpClientModule, CommonModule, NgOptimizedImage],
  templateUrl: './pmain.component.html',
  styleUrl: './pmain.component.css'
})
export class PmainComponent implements OnInit {
  selectedBrend: { id: number; naziv: string } = { id: 0, naziv: '' };
  selectedKategorija: { kategorijaId: number; naziv: string; opis: string } = { kategorijaId: 0, naziv: '', opis: '' };


  constructor(public httpClient: HttpClient, private sharedDataService: SharedDataService) {
    this.sharedDataService.selectedBrend$.subscribe((selectedBrend) => {
      this.selectedBrend = selectedBrend;
      this.sharedDataService.selectedKategorija$.subscribe((selectedKategorija) => {
        this.selectedKategorija = selectedKategorija;
        this.GetProizvodi();
      });
    });
  }

  ngOnInit(): void {
    this.GetProizvodi();
  }

  proizvodi: ProizvodiGetAllResponse[] = [];

  GetProizvodi() {
    let url = Mojconfig.adresa_servera + "/api/products/GetProizvodi";
    this.httpClient.get<ProizvodiGetAllResponse[]>(url).subscribe(
      x => {
        this.proizvodi = x.filter(proizvod => {
          const isBrendMatch = this.selectedBrend.naziv === "" || proizvod.brend.nazivBrenda === this.selectedBrend.naziv;
          const isKategorijaMatch = this.selectedKategorija.naziv === "" || proizvod.kategorija.id === this.selectedKategorija.kategorijaId;
          return isBrendMatch && isKategorijaMatch;
        });
      }
    );
  }
}
