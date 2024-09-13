import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {Mojconfig} from "../moj-config";
import {CommonModule,NgFor,NgIf} from "@angular/common";
import {Router} from "@angular/router";

declare function porukaError(m:string):any;
declare function porukaSuccess(m:string):any;
@Component({
  selector: 'app-prijava',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './prijava.component.html',
  styleUrl: './prijava.component.css'
})
export class PrijavaComponent implements OnInit{
  prijave: any[] = [];
  selectedFileSlika: File | null = null;
  selectedFilePdf: File | null = null;
  selectedFileType: 'image' | 'pdf' | null = null;

  zalbaDto = {
    korisnikID: this.dohvatiLogiranogKorisnika()?.autentifikacijaToken.korisnickiNalog.id ?? 3,
    tekst: ''
  };
  constructor(private http: HttpClient, private router: Router)  {}

  onFileTypeChange(fileType: 'image' | 'pdf') {
    this.selectedFileType = fileType;
    // Reset selected files based on file type
    if (fileType === 'image') {
      this.selectedFilePdf = null;
    } else if (fileType === 'pdf') {
      this.selectedFileSlika = null;
    }
  }
  onFileSelected(event: any, fileType: 'slika' | 'pdf') {
    const file = event.target.files[0];
    if (fileType === 'slika') {
      this.selectedFileSlika = file;
    } else if (fileType === 'pdf') {
      this.selectedFilePdf = file;
    }
  }
  ngOnInit(): void {
    this.getAllPrijave();
        console.log(this.dohvatiLogiranogKorisnika()?.autentifikacijaToken);
  }
  submitZalba() {
    if (!this.zalbaDto.tekst) {
      console.error('Please fill out all fields.');
      return;
    }

    const formData = new FormData();
    formData.append('KorisnikID', this.zalbaDto.korisnikID.toString());
    formData.append('Tekst', this.zalbaDto.tekst);

    let apiUrl = '';
    if (this.selectedFileType === 'image' && this.selectedFileSlika) {
      formData.append('Slika', this.selectedFileSlika);
      apiUrl = Mojconfig.adresa_servera + '/api/Zalba';
    } else if (this.selectedFileType === 'pdf' && this.selectedFilePdf) {
      formData.append('PdfNarudzba', this.selectedFilePdf);
      apiUrl = Mojconfig.adresa_servera + '/api/Zalba/SaPdf';
    } else {
      console.error('No file selected or incorrect file type.');
      return;
    }

    this.http.post(apiUrl, formData)
      .subscribe(response => {
        this.router.navigate(['/obavijesti']);
        porukaSuccess("Prijava poslana");
      }, error => {
        porukaError("Prijava nije poslana");
      });
  }


  getAllPrijave(): void {
    this.http.get<any[]>(Mojconfig.adresa_servera + '/api/Zalba')
      .subscribe((data) => {
        this.prijave = data;
      });
  }

  deletePrijava(prijavaID: number): void {
    if (confirm('Jeste li sigurni da želite izbrisati prijavu?')) {
      this.http.delete(Mojconfig.adresa_servera + `/api/Zalba/${prijavaID}`)
        .subscribe(() => {
          this.prijave = this.prijave.filter(prijava => prijava.id !== prijavaID);
          porukaSuccess("Prijava izbrisana");
        });
    }
  }
  dohvatiLogiranogKorisnika(){
    let token = window.localStorage.getItem("korisnik")??"";
    try {
      return JSON.parse(token);
    }
    catch (e){
      return null;
    }
  }
  isAdmin(){
    return this.dohvatiLogiranogKorisnika()?.autentifikacijaToken.korisnickiNalog.isAdmin;
  }
}
