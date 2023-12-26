import { Component } from '@angular/core';
import {FormsModule} from "@angular/forms";
import {SharedDataService} from "../app/shared-data-service";

@Component({
  selector: 'app-ptop',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './ptop.component.html',
  styleUrl: './ptop.component.css'
})
export class PtopComponent {

   _inputValue: string = '';
constructor(private sharedDataService: SharedDataService) {
}
  TraziZaInput() {
    this.sharedDataService.updateInputValue(this._inputValue);
    this._inputValue = "";
  }
}
