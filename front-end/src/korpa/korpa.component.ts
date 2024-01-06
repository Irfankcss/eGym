import {Component, OnInit} from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-korpa',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './korpa.component.html',
  styleUrl: './korpa.component.css'
})
export class KorpaComponent  implements OnInit{
  trenutnaStranica = 1 ;
  nacinDostave:string ="";
  nacinPlacanja:string ="";
  regularnaIsporukaChecked: boolean = false;
  clickNCollectChecked: boolean = false;
  karticnoPlacanjeChecked: boolean = false;
  placanjePreuzimanjeChecked: boolean = false;



  ngOnInit(): void {
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
        this.nacinDostave=selected;
        console.log(this.nacinDostave);
        break;
      case  'clickNCollect':
        this.clickNCollectChecked = !this.clickNCollectChecked;
        if(this.regularnaIsporukaChecked){
          this.regularnaIsporukaChecked = false;
        }
        this.nacinDostave=selected;
        console.log(this.nacinDostave);
        break;
        case  'karticno':
          this.karticnoPlacanjeChecked = !this.karticnoPlacanjeChecked;
          if(this.placanjePreuzimanjeChecked){
            this.placanjePreuzimanjeChecked = false;
          }
          this.nacinPlacanja=selected;
          console.log(this.nacinPlacanja);
          break;
        case  'preuzimanje':
          this.placanjePreuzimanjeChecked = !this.placanjePreuzimanjeChecked;
          if(this.karticnoPlacanjeChecked){
            this.karticnoPlacanjeChecked = false;
          }
          this.nacinPlacanja=selected;
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
}
