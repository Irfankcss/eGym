import {afterNextRender, Component, EventEmitter, Input, Output} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {Mojconfig} from "../../app/moj-config";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Router} from "@angular/router";


declare function porukaSuccess(m:string):any;
declare function porukaError(m:string):any;
@Component({
  selector: 'app-izdvoji-potvrda',
  standalone: true,
  imports: [
    FormsModule,
    HttpClientModule
  ],
  templateUrl: './izdvoji-potvrda.component.html',
  styleUrl: './izdvoji-potvrda.component.css'
})
export class IzdvojiPotvrdaComponent {

  @Output() otvori = new EventEmitter<boolean>();

  prikaz:boolean = true;

  constructor(public httpClient:HttpClient, private router:Router) {
  }

  zatvori() {
    this.prikaz = !this.prikaz;
    this.otvori.emit(this.prikaz);
  }
  @Input() proizvodID:any;
  izdvojiProizvod() {
    let proizvodID = this.proizvodID;
    let url = Mojconfig.adresa_servera + `/Obradi/ProizvodStatusUpdateONEndpoint?ProizvodID=${proizvodID}`;

    this.httpClient.post(url,{}).subscribe(x=>{
      this.zatvori();
      this.router.navigate(['/obavijesti']);
      porukaSuccess('Uspješno izdvojen proizvod');
    })
  }
}
