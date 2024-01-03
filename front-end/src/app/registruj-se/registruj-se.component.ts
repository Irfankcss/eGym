import {Component, OnInit} from '@angular/core';
import {RouterLink} from "@angular/router";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Gradovi, GradoviGetall} from "./gradovi-getall";
import {MojConfig} from "../moj-config";
import {NgForOf, NgIf} from "@angular/common";
import {Form, FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";

@Component({
  selector: 'app-registruj-se',
  standalone: true,
  imports: [
    RouterLink,
    HttpClientModule,
    NgForOf,
    ReactiveFormsModule,
    NgIf
  ],
  templateUrl: './registruj-se.component.html',
  styleUrl: './registruj-se.component.css'
})
export class RegistrujSeComponent implements OnInit{
  constructor(public httpClient:HttpClient) {
  }
  gradovi:Gradovi[]=[];
  ngOnInit(): void {
    let url=MojConfig.adresa_servera + `/Obradi/GradPretragaEndpoint`;
    this.httpClient.get<GradoviGetall>(url).subscribe((x:GradoviGetall)=>{
      this.gradovi = x.gradovi;
    })
  }
  userRegistration = new FormGroup({
    ime: new FormControl("",
      [Validators.required,
        Validators.minLength(3),
        Validators.pattern(/^[A-Z][a-z]*$/)]),
    prezime: new FormControl("",
      [Validators.required,
      Validators.minLength(3),
      Validators.pattern(/^[A-Z][a-z]*$/)]),
    korisnickoIme : new FormControl("",
      [Validators.required]),
    datumRodjenja: new FormControl("",
      [Validators.required]),
    brojTelefona : new FormControl("",
      [Validators.required,
      Validators.minLength(9),
      Validators.maxLength(10),
      Validators.pattern(/^[0-9]*$/)]),
    email: new FormControl("",
      [Validators.required,
      Validators.email]),
    lozinka: new FormControl("",
      [Validators.required,
      Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/)]),
    spol:new FormControl("",[Validators.required]),
    opstinaRodjenja:new FormControl("",[Validators.required]),

  })

  registrerSubmited() {
    console.log(this.userRegistration.value);
    if(this.userRegistration.valid){
      console.log('Uspjesno');
      //console.log(this.userRegistration.get('ime')?.value)
    }
    else{
      console.log('Neuspjesno')
    }
  }
  get ime():FormControl{
    return this.userRegistration.get('ime') as FormControl;
  }
  get prezime():FormControl{
    return this.userRegistration.get('prezime') as FormControl;
  }
  get korisnickoIme():FormControl{
    return this.userRegistration.get('korisnickoIme') as FormControl;
  }
  get datumRodjenja():FormControl{
    return this.userRegistration.get('datumRodjenja') as FormControl;
  }
  get brojTelefona():FormControl{
    return this.userRegistration.get('brojTelefona') as FormControl;
  }
  get email():FormControl{
    return this.userRegistration.get('email') as FormControl;
  }
  get lozinka():FormControl{
    return this.userRegistration.get('lozinka') as FormControl;
  }
}
