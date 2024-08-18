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
  korisnik:any;
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
  popuniPodacimaChecked: boolean = false;

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
    this.getKorisnik();
  }
  ucitajProizvode() {
    let url = Mojconfig.adresa_servera + `/api/Korpa/GetKorpaByKorisnikID/${this.korisnikId}`;
    this.httpClient.get(url).subscribe(x=>{
      this.korpa = x as KorpaResponse;
    })
  }
    getKorisnik() {
      this.httpClient.get(Mojconfig.adresa_servera+`/Obradi/KorisnikGetByIDEndpoint?ID=${this.korisnikId}`)
        .subscribe(next=>{
        this.korisnik = next;})
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
    if(this.korpa.proizvodi.length==0){
      porukaError("Nema proizvoda u korpi");
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
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(this.email)) {
      porukaError("Neispravan format email adrese.");
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
      "nacinDostave": this.nacinDostave,
      "imePrimaoca": this.imePrimaoca,
      "prezimePrimaoca": this.prezimePrimaoca,
      "gradID": 1,
      "adresa": this.adresa,
      "telefon": this.telefon,
      "email": this.email
    }
    this.httpClient.post(Mojconfig.adresa_servera+`/Narudzba2/CreateNarudzbaFromKorpa/${this.korpa.korpaID}`,body).subscribe({
      next: (response: any) => {
        console.log(response);

        let narudzbaId = response.id;
        console.log('Created order ID:', narudzbaId);
        porukaSuccess("Uspjesno ste narucili proizvode");
        this.router.navigate(['/narudzba/', narudzbaId]);
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
    },error => {
      console.log(error);
    })
  }

  popuniPodacimaChancged() {
    if(this.popuniPodacimaChecked){
      let korisnikString = window.localStorage.getItem("korisnik")??"";
      const korisnikObject = JSON.parse(korisnikString);
      this.imePrimaoca=this.korisnik.ime;
      this.prezimePrimaoca=this.korisnik.prezime;
      this.telefon=this.korisnik.brojTelefona;
      this.gradID=this.korisnik.opstinaID;
      this.email = korisnikObject.autentifikacijaToken.korisnickiNalog.email;
    }else{
      this.email = "";
      this.imePrimaoca = "";
      this.prezimePrimaoca = "";
      this.telefon = "";
      this.gradID = 1;
    }

  }
}

