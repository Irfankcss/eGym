import {Inject, Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Kategorija} from "../Entities/Kategorija";
import { map } from 'rxjs/operators';
import { HttpClientModule } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class KategorijaService {

  private apiUrl = 'https://localhost:7018/Kategorija/Pretraga po nazivu';

  constructor(private http: HttpClient) { }

  getAllKategorije(): Observable<Kategorija[]> {
    return this.http.get<Kategorija[]>(`${this.apiUrl}/`)
  }
  getKategorijaByName(naziv: string): Observable<Kategorija> {
    return this.getAllKategorije().pipe(
      map(kategorije => {
        const foundKategorije = kategorije
          .find(kategorija => kategorija.naziv.toLowerCase().startsWith(naziv.toLowerCase()));
        if (foundKategorije) {
          return foundKategorije;
        } else {
          throw new Error('Kategorija not found');
        }
      })
    );
  }
}
