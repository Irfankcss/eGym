import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {Mojconfig} from "../moj-config";
import {CommonModule, NgIf, NgFor} from "@angular/common";

@Component({
  selector: 'app-narudzba',
  standalone: true,
  imports: [
    CommonModule,
    NgIf,
    NgFor
  ],
  templateUrl: './narudzba.component.html',
  styleUrl: './narudzba.component.css'
})
export class NarudzbaComponent implements OnInit {
  narudzba:any={};
  narudzbaID:number=0;
  loading: boolean = true;
  constructor(private httpClient: HttpClient,router:Router,private route:ActivatedRoute) { }

  ngOnInit() {
    this.getNarudzba();
    console.log(this.narudzba.proizvodi);
  }

  private getNarudzba() {
    this.narudzbaID=this.route.snapshot.params['narudzbaID'];
    this.httpClient.get(Mojconfig.adresa_servera+`/Narudzba2/NarudzbaGetBy${this.narudzbaID}`).subscribe(x=>{
      this.narudzba=x;
      this.loading = false;
      console.log(this.narudzba);
      console.log(this.narudzba.proizvodi);
    });

  }
}
