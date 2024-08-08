import {Component, OnInit} from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {Mojconfig} from "../app/moj-config";
import {KorpaResponse} from "./KorpaResponse";
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {Router} from "@angular/router";
declare function porukaError(m:string):any;
declare function porukaSuccess(m:string):any;
@Component({
  selector: 'app-korpa',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './korpa.component.html',
  styleUrl: './korpa.component.css'
})
export class KorpaComponent  implements OnInit{
  trenutnaStranica = 1 ;
  nacinDostave:string ="Regular";
  nacinPlacanja:string ="Gotovina";
  regularnaIsporukaChecked: boolean = false;
  clickNCollectChecked: boolean = false;
  karticnoPlacanjeChecked: boolean = false;
  placanjePreuzimanjeChecked: boolean = false;
  korpa: KorpaResponse ={
    korpaID: 0,
    proizvodi: [],
    vrijednost: 0
  }
  korisnikId:number=0;
  adresa: string = "";
  telefon: string = "";
  email: string ="";
  prezimePrimaoca: string="";
  imePrimaoca: string="";
  gradID:number=1;
  gradovi:any[]=[];
  Uslovi: boolean=false;
  troskoviDostave: number = 0;

  constructor(private httpClient:HttpClient, private router:Router) {
  }

  ngOnInit(): void {
    this.provjeriJelLogovan();
    this.ucitajProizvode();
    this.getGradovi();
  }

  prebaciNaStranicu4() {
    this.trenutnaStranica = 4;
  }

  handleCheckbox(selected: string) {
    switch (selected) {
      case  'regularna':
        this.regularnaIsporukaChecked = !this.regularnaIsporukaChecked;
        if(this.clickNCollectChecked){
          this.clickNCollectChecked = false;
        }
        this.troskoviDostave = 7;
        this.nacinDostave="Regular";
        console.log(this.nacinDostave);
        break;
      case  'clickNCollect':
        this.clickNCollectChecked = !this.clickNCollectChecked;
        if(this.regularnaIsporukaChecked){
          this.regularnaIsporukaChecked = false;
        }
        this.troskoviDostave = 0;
        this.nacinDostave="clickNcollect";
        console.log(this.nacinDostave);
        break;
        case  'karticno':
          this.karticnoPlacanjeChecked = !this.karticnoPlacanjeChecked;
          if(this.placanjePreuzimanjeChecked){
            this.placanjePreuzimanjeChecked = false;
          }
          this.nacinPlacanja="Kartica";
          console.log(this.nacinPlacanja);
          break;
        case  'preuzimanje':
          this.placanjePreuzimanjeChecked = !this.placanjePreuzimanjeChecked;
          if(this.karticnoPlacanjeChecked){
            this.karticnoPlacanjeChecked = false;
          }
          this.nacinPlacanja="Gotovina";
          console.log(this.nacinPlacanja);
          break;
    }
  }

  sljedecikorak() {
    this.trenutnaStranica++;
  }

  prethodnikorak() {
    this.trenutnaStranica--;
  }

  provjeriJelLogovan() {
    let korisnikString = window.localStorage.getItem("korisnik")??"";
    if(korisnikString == "") {
      porukaError("Morate biti prijavljeni da biste mogli pregledati korpu");
      this.router.navigate(['/prijavi-se']);
      return;
    }
    const korisnikObject = JSON.parse(korisnikString);
    this.korisnikId = korisnikObject.autentifikacijaToken.korisnickiNalogId;
  }

  ucitajProizvode() {
    let url = Mojconfig.adresa_servera + `/api/Korpa/GetKorpaByKorisnikID/${this.korisnikId}`;
    this.httpClient.get(url).subscribe(x=>{
      this.korpa = x as KorpaResponse;
    })
  }

  izbaciIzKorpe(proizvodID: number) {
    this.httpClient.delete(Mojconfig.adresa_servera+`/api/Korpa/RemoveProizvodFromKorpa/${this.korpa.korpaID}/${proizvodID}`)
      .subscribe({
        next: (response: any) => {
          console.log(response.message);
          this.ucitajProizvode();
          porukaSuccess("Uspjesno ste obrisali proizvod iz korpe");
        },
        error: (error: HttpErrorResponse) => {
          console.error('Error removing product from cart', error);
          porukaError('Error removing product from cart');
        }
      });
  }

  kreirajNarudzbu() {
    if(this.Uslovi==false){
      porukaError("Morate se slagati sa uslovima korištenja, prodaje te politikom privatnosti");
      return;
    }
    if(this.imePrimaoca ==""){
      porukaError("Morate unijeti ime");
      return;
    }
    if(this.prezimePrimaoca ==""){
      porukaError("Morate unijeti prezime");
      return;
    }
    if(this.adresa ==""){
      porukaError("Morate unijeti adresu");
      return;
    }
    if(this.telefon ==""){
      porukaError("Morate unijeti telefon");
      return;
    }
    if(this.email ==""){
      porukaError("Morate unijeti email");
      return;
    }
    if(this.nacinPlacanja==""){
      porukaError("Morate odabrati nacin placanja");
      return;
    }
    if(this.nacinDostave==""){
      porukaError("Morate odabrati nacin dostave");
      return;
    }

    let body = {
      "nacinPlacanja": "Cash",
      "popust": 0,
      "nacinDostave": "Regular",
      "imePrimaoca": this.imePrimaoca,
      "prezimePrimaoca": this.prezimePrimaoca,
      "gradID": 1,
      "adresa": this.adresa,
      "telefon": this.telefon,
      "email": this.email
    }
      if(this.nacinDostave=="Regular"){
        this.korpa.vrijednost+=this.troskoviDostave;
      }
    this.httpClient.post(Mojconfig.adresa_servera+`/Narudzba2/CreateNarudzbaFromKorpa/${this.korpa.korpaID}`,body).subscribe({
      next: (response: any) => {
        console.log(response);
        porukaSuccess("Uspjesno ste narucili proizvode");
        this.router.navigate(['/prodavnica']);
      },
      error: (error: HttpErrorResponse) => {
        console.error('Error creating order', error);
        porukaError('Error creating order');
      }
    })
  }

  private getGradovi() {
    this.httpClient.get<any[]>(Mojconfig.adresa_servera + '/Obradi/GradPretragaEndpoint').subscribe(x => {
      // @ts-ignore
      this.gradovi = x.gradovi;
      console.log(this.gradovi)
    },error => {
      console.log(error);
    })
  }

}

