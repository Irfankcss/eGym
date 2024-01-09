import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Obavijesti, ObavijestiGetall} from "./obavijesti-getall";
import {MojConfig} from "../moj-config";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-obavijesti',
  standalone: true,
  imports: [HttpClientModule, NgForOf],
  templateUrl: './obavijesti.component.html',
  styleUrl: './obavijesti.component.css'
})
export class ObavijestiComponent implements OnInit{
  constructor(public httpClient: HttpClient ) {
  }
  obavijesti:Obavijesti[]=[];
  public sliderNumber:number = 1;
  ngOnInit(): void {
    let url = MojConfig.adresa_servera + `/Obradi/ObavijestiPretragaEndpoint`;
    this.httpClient.get<ObavijestiGetall>(url).subscribe((x:ObavijestiGetall)=>{
      this.obavijesti = x.obavijesti;
    })
  }
  countSliderNumber(){
    this.sliderNumber++;
  }
}
