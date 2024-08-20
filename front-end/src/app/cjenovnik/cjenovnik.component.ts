import {Component, OnInit} from '@angular/core';
import {Clanarine} from "./cjenovnik-clanarina";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-cjenovnik',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './cjenovnik.component.html',
  styleUrl: './cjenovnik.component.css'
})
export class CjenovnikComponent implements OnInit{
  clanarine:Clanarine[] = [
    {tip:'Mjesečna članarina',cijena:60,mogucnosti:[
      {mogucnost:'Korištenje svih sadžaja u terminu 6:30 - 15:00'},{mogucnost:'Besplatan parking'}]},
    {tip:'Mjesečna članarina',cijena:70,mogucnosti:[
        {mogucnost:'Korištenje svih sadžaja u terminu 6:30 - 23:00'},{mogucnost:'Besplatan parking'}]},
    {tip:'Za studente',cijena:50,mogucnosti:[
        {mogucnost:'Korištenje svih sadžaja u terminu 6:30 - 15:00'},{mogucnost:'Besplatan parking'}]},
    {tip:'Za studente',cijena:60,mogucnosti:[
        {mogucnost:'Korištenje svih sadžaja u terminu 6:30 - 23:00'},{mogucnost:'Besplatan parking'}]},
    {tip:'Dnevna karta',cijena:10,mogucnosti:[
        {mogucnost:'Korištenje svih sadžaja u terminu 6:30 - 23:00'},{mogucnost:'Besplatan parking'}]},
    {tip:'Mjesečna članarina',cijena:80,mogucnosti:[
        {mogucnost:'Korištenje svih sadžaja u terminu 6:30 - 23:00'},{mogucnost:'Besplatan parking'},{mogucnost: "Korištenje ručnika tokom boravka u teretani"}]},
  ]

  ngOnInit(): void {
  }
}
