import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CommonModule,NgFor,NgIf} from "@angular/common";
import {Mojconfig} from "../moj-config";

declare function porukaError(m:string):any;
declare function porukaSuccess(m:string):any;

@Component({
  selector: 'app-narudzbeall',
  standalone: true,
  imports: [CommonModule,NgFor,NgIf],
  templateUrl: './narudzbeall.component.html',
  styleUrl: './narudzbeall.component.css'
})
export class NarudzbeallComponent implements OnInit{
  narudzbe: any = [];
  loading: boolean = true;
  naslov:string="Narudžbe za pregled:"
  Upozorenje: string = "";
  constructor(private httpClient: HttpClient) {
  }

  ngOnInit() {
    this.getNarudzbe();

  }

  private getNarudzbe() {
    this.httpClient.get(Mojconfig.adresa_servera+"/Narudzba2/NarudzbaGetAll").subscribe(x=>{
        this.narudzbe = x;
      if(this.naslov=="Narudžbe za pregled:"){
        this.narudzbe = this.narudzbe.filter((x: { isOdobrena: boolean; }) => !x.isOdobrena);
      }else {
        this.narudzbe = this.narudzbe.filter((x: { isOdobrena: boolean; }) => x.isOdobrena);
      }
      this.narudzbe.Upozorenje="";
        this.loading = false;
      },
      error => {
        console.log("Greska u preuzimanju narudzbi sa servera");
        this.loading = false;
      })
  }

  protected readonly Date = Date;

  prihvaceneSwitched() {
    this.naslov="Odobrene Narudžbe:"
    this.getNarudzbe();
  }

  zaPregledSwitched() {
    this.naslov="Narudžbe za pregled:"
    this.getNarudzbe();
  }

  odobriNarudzbu(id: number, email: string) {
    if (window.confirm("Jeste li sigurni da želite odobriti narudžbu?")) {
      this.httpClient.put(Mojconfig.adresa_servera + `/Narudzba2/OdobriNarudzbu/${id}`, {})
        .subscribe(next => {
          porukaSuccess("Narudžba odobrena");
          this.getNarudzbe();
        }, error => {
          porukaError("Narudžba nije odobrena");
        });
    }
  }

  odbijNarudzbu(id: number, email: string) {
    if (window.confirm("Jeste li sigurni da želite odbiti i izbrisati narudžbu?")) {
      this.httpClient.delete(Mojconfig.adresa_servera + `/Narudzba2/DeleteNarudzba/${id}`, {})
        .subscribe(next => {
          porukaSuccess("Narudžba odbijena i izbrisana");
          this.getNarudzbe();
        }, error => {
          porukaError("Odbijanje narudžbe neuspješno");
        });
    }
  }

  provjeriNarudzbu(n: any) {
    n.Upozorenje="";
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    for (let proizvod of n.proizvodi) {
      if(proizvod.proizvod.kolicinaNaSkladistu<proizvod.kolicina)
        n.Upozorenje+="; Nedovoljno proizvoda u skladištu.";
      if (proizvod.proizvod.izbrisan) {
        n.Upozorenje += `; Proizvod "${proizvod.proizvod.naziv}" je izbrisan.`;
      }
    }
    if (n.nacinPlacanja !== 'Cash' && n.nacinPlacanja !== 'Credit Card') {
      n.Upozorenje += "; Nevažeći način plaćanja.";
    }

    if (!n.telefon || n.telefon.trim() === "") {
      n.Upozorenje += "; Broj telefona nije unesen.";
    }

    if (!n.email || n.email.trim() === "") {
      n.Upozorenje += "; Email adresa nije unesena.";
    }
    if (!emailRegex.test(n.email)) {
      n.Upozorenje += "; Neispravan format email adrese.";
    }
  }

  posaljiNarudzbu(narudzba:any, email: string) {

  }
}
