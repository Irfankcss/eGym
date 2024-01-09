import {Component, OnInit} from '@angular/core';
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-prijavi-se',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './prijavi-se.component.html',
  styleUrl: './prijavi-se.component.css'
})
export class PrijaviSeComponent implements OnInit{
  ngOnInit(): void {
  }

}
