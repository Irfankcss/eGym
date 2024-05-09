import {Component, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-ukloni-potvrda',
  standalone: true,
  imports: [],
  templateUrl: './ukloni-potvrda.component.html',
  styleUrl: './ukloni-potvrda.component.css'
})
export class UkloniPotvrdaComponent {

  @Output() otvori = new EventEmitter<boolean>();

  prikaz:boolean = true;

  zatvori() {
    this.prikaz = !this.prikaz;
    this.otvori.emit(this.prikaz);
  }

}
