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

  zalbaDto = {
    korisnikID: this.dohvatiLogiranogKorisnika()?.autentifikacijaToken.korisnickiNalog.id ?? 3,
    tekst: ''
  };

  selectedFile: File | null = null;

  constructor(private http: HttpClient, private router: Router)  {}

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
    }
  }

  ngOnInit(): void {
    this.getAllPrijave();
        console.log(this.dohvatiLogiranogKorisnika()?.autentifikacijaToken);
  }
  submitZalba() {
    if (!this.selectedFile || !this.zalbaDto.tekst) {
      console.error('Please fill out all fields.');
      return;
    }

    const formData = new FormData();
    formData.append('KorisnikID',this.zalbaDto.korisnikID.toString());
    formData.append('Tekst', this.zalbaDto.tekst);
    formData.append('Slika', this.selectedFile);

    this.http.post(Mojconfig.adresa_servera + '/api/Zalba', formData)
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
