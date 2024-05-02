import {Component, OnInit} from '@angular/core';
import {Route, Router, RouterLink, Routes} from "@angular/router";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Gradovi, GradoviGetall} from "./gradovi-getall";
import {Mojconfig} from "../moj-config";
import {NgForOf, NgIf} from "@angular/common";
import {Form, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
declare function porukaSuccess(m:string):any;
declare function porukaError(m:string):any;

@Component({
  selector: 'app-registruj-se',
  standalone: true,
  imports: [
    RouterLink,
    HttpClientModule,
    NgForOf,
    ReactiveFormsModule,
    NgIf,
    FormsModule
  ],
  templateUrl: './registruj-se.component.html',
  styleUrl: './registruj-se.component.css'
})
export class RegistrujSeComponent implements OnInit{
  txtIme:any;
  txtPrezime:any;
  txtOpstinaRodjenja:number = 1;
  txtDatumRodjenja:any;
  txtBrojTelefona:any;
  txtSpol:any;
  txtKorisnickoIme:any;
  txtEmail:any;
  txtLozinka:any;

  regexOnlyLetters = /^[A-Z][a-z]*$/;
  regexPhoneNumber =/^[0-9]{9}/;
  regexEmail = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
  regexPassword = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;
  constructor(public httpClient:HttpClient, private router:Router) {
  }
  gradovi:Gradovi[]=[];
  ngOnInit(): void {
    let url=Mojconfig.adresa_servera + `/Obradi/GradPretragaEndpoint`;
    this.httpClient.get<GradoviGetall>(url).subscribe((x:GradoviGetall)=>{
      this.gradovi = x.gradovi;
    })
  }
  // @ts-ignore
  Validiraj():boolean{
    if(this.txtIme == null || this.txtPrezime == null || this.txtDatumRodjenja == null ||this.txtBrojTelefona == null
      || this.txtSpol == null || this.txtKorisnickoIme == null || this.txtEmail==null || this.txtLozinka == null
      ||this.txtOpstinaRodjenja == null){
      porukaError('Greska, sva polja su obavezna');
      return false;
    }
    if(!this.txtIme.match(this.regexOnlyLetters)){
      porukaError('Greska, ime počinje sa velikim slovom i sadrži samo slova');
      return false;
    }
    if(!this.txtPrezime.match(this.regexOnlyLetters)){
      porukaError('Greska, prezime počinje sa velikim slovom i sadrži samo slova');
      return false;
    }
    if(!this.txtBrojTelefona.match(this.regexPhoneNumber)){
      porukaError('Greska, neispravan format broja telefona');
      return false;
    }
    if(!this.txtEmail.match(this.regexEmail)){
      porukaError('Greška, neispravan format email-a');
      return false;
    }
    if(!this.txtLozinka.match(this.regexPassword)){
      porukaError('Greška, neispravan format lozinke');
      return false;
    }
    return true;
  }
  sacuvajKorisnika() {
    let url = Mojconfig.adresa_servera + `/Obradi/KorisnikDodajEndpoint`;

    if(this.Validiraj()) {

      let noviKorisnik = {
        ime: this.txtIme,
        prezime: this.txtPrezime,
        opstinaRodjenja:this.txtOpstinaRodjenja,
        datumRodjenja: this.txtDatumRodjenja,
        brojTelefona: this.txtBrojTelefona,
        spol: this.txtSpol,
        korisnickoIme: this.txtKorisnickoIme,
        email: this.txtEmail,
        lozinka: this.txtLozinka
      };
      console.log(noviKorisnik);
      this.httpClient.post(url,noviKorisnik).subscribe(x=>{
        porukaSuccess('Uspješno kreiran korisnički nalog');
        this.router.navigate(['/prijavi-se']);
      })
    }
  }
}
