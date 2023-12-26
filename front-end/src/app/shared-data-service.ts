import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import {BrendGetAllResponse} from "../pleft/BrendGetAllResponse";
import {KategorijaGetAllResponse} from "../pleft/KategorijaGetAllResponse";


@Injectable({
  providedIn: 'root',
})
export class SharedDataService {
  private selectedBrendSubject = new BehaviorSubject<BrendGetAllResponse>({ id: 0, naziv: '' });
  selectedBrend$ = this.selectedBrendSubject.asObservable();
  private selectedKategorijaSubject = new BehaviorSubject<KategorijaGetAllResponse>({ kategorijaId: 0, naziv: '', opis:'' });
  selectedKategorija$ = this.selectedKategorijaSubject.asObservable();

  updateSelectedBrend(brend: BrendGetAllResponse) {
    this.selectedBrendSubject.next(brend);
  }

  updateSelectedKategorija(kategorija: KategorijaGetAllResponse) {
    this.selectedKategorijaSubject.next(kategorija);
  }

}
