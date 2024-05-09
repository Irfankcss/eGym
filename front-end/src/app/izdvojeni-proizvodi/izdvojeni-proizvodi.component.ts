import {Component, OnInit} from '@angular/core';
import {Mojconfig} from "../moj-config";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-izdvojeni-proizvodi',
  standalone: true,
  imports: [
    HttpClientModule,
    NgForOf
  ],
  templateUrl: './izdvojeni-proizvodi.component.html',
  styleUrl: './izdvojeni-proizvodi.component.css'
})
export class IzdvojeniProizvodiComponent implements OnInit{

  public izdvojeniProizovdi:any;

  constructor(public httpClient:HttpClient) {
  }
  ngOnInit(): void {
      let url = Mojconfig.adresa_servera + `/api/products/GetIzdvojeniProizvodi`;

      this.httpClient.get<any>(url).subscribe(x=>{
        this.izdvojeniProizovdi=x;
        console.log(this.izdvojeniProizovdi);
      })
  }

}
