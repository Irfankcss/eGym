import { Component } from '@angular/core';

@Component({
  selector: 'app-contact-footer',
  standalone: true,
  imports: [],
  templateUrl: './contact-footer.component.html',
  styleUrl: './contact-footer.component.css'
})
export class ContactFooterComponent {
    phoneImage:string = '/assets/contact-images/telefon.png';
    emailImage:string = '/assets/contact-images/email.png';
    locationImage:string = '/assets/contact-images/lokacija.png';
    timeImage:string = '/assets/contact-images/vrijeme.png'
}
