import {Component, OnInit} from '@angular/core';

declare function porukaError(m:string):any;
@Component({
  selector: 'app-kalkulator-idealne-tezine',
  standalone: true,
  imports: [],
  templateUrl: './kalkulator-idealne-tezine.component.html',
  styleUrl: './kalkulator-idealne-tezine.component.css'
})
export class KalkulatorIdealneTezineComponent implements OnInit{
  ngOnInit(): void {
    document.getElementById('visina')?.addEventListener('keydown', (event: KeyboardEvent) => {
      event.preventDefault();
    });
    document.getElementById('tezina')?.addEventListener('keydown', (event: KeyboardEvent) => {
      event.preventDefault();
    });
  }
  izracunajIdealnuTezinu() {
    let visina = (document.getElementById('visina') as HTMLInputElement).valueAsNumber;
    let tezina = (document.getElementById('tezina') as HTMLInputElement).valueAsNumber;

    let crvena = '#FF0000';
    let ispis = document.querySelector('.left h3') as HTMLElement ;
    console.log(ispis);

    if(isNaN(visina) || isNaN(tezina)){
      porukaError("Unesite vrijednosti");
      return;
    }
    let idealnaVrijednost = visina % 100;
    let gornjaGranica = idealnaVrijednost + 5;
    let donjaGranica = idealnaVrijednost - 5;

    let svg = document.querySelector('.logo svg') as SVGElement;

    if(tezina >= donjaGranica && tezina <=gornjaGranica){
      svg.style.fill = this.getWeightColor(tezina,donjaGranica,gornjaGranica);
      ispis.innerHTML = `Nalazite se u opsegu ${donjaGranica}kg i ${gornjaGranica}kg`

    }else{
      svg.style.fill = crvena;
      ispis.innerHTML = `Ne nalazite se u opsegu ${donjaGranica}kg i ${gornjaGranica}kg`
    }
  }
   getWeightColor(weight: number, lowerLimit: number, upperLimit: number): string {
    // Normalization of the weight between the tolerance limits
    const normalizedWeight = (weight - lowerLimit) / (upperLimit - lowerLimit);

    // Interpolation of the color between red and green
    const red = Math.min(255, 255 * (1 - normalizedWeight));
    const green = Math.min(255, 255 * normalizedWeight);

    return `rgb(${Math.round(red)}, ${Math.round(green)}, 0)`;
  }
}
