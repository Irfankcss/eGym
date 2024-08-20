import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {Mojconfig} from "../moj-config";
import {CommonModule, NgIf, NgFor} from "@angular/common";
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

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
    });

  }

  preuzmiPdf() {
    const element = document.getElementById('zaPreuzet');

    if (element) {
      html2canvas(element, {
        scale: 2,
        useCORS: true,
        allowTaint: true,
        logging: true,
      }).then(canvas => {
        const imgData = canvas.toDataURL('image/png');
        const pdf = new jsPDF('p', 'mm', 'a4');

        const imgWidth = 210;
        const pageHeight = 297;
        const imgHeight = (canvas.height * imgWidth) / canvas.width;
        let heightLeft = imgHeight;
        let position = 0;

        pdf.addImage(imgData, 'PNG', 0, position, imgWidth, imgHeight);
        heightLeft -= pageHeight;

        while (heightLeft >= 0) {
          position = heightLeft - imgHeight;
          pdf.addPage();
          pdf.addImage(imgData, 'PNG', 0, position, imgWidth, imgHeight);
          heightLeft -= pageHeight;
        }

        pdf.save('Narudzba.pdf');
      }).catch(error => {
        console.error("Error pri generisanju PDF-a", error);
      });
    }
  }

}
