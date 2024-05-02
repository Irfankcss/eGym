import {Component, EventEmitter, Input, Output} from '@angular/core';
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-izdvoji-potvrda',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './izdvoji-potvrda.component.html',
  styleUrl: './izdvoji-potvrda.component.css'
})
export class IzdvojiPotvrdaComponent {

  @Output() otvori = new EventEmitter<boolean>();

  prikaz:boolean = true;

  zatvori() {
    this.prikaz = !this.prikaz;
    this.otvori.emit(this.prikaz);
  }
  @Input() proizvodID:any;
  izdvojiProizvod() {
    alert(this.proizvodID);
  }
}
