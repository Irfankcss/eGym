import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { RouterModule } from '@angular/router';
import {SharedDataService} from "./shared-data-service";
import {ViewProizvodComponent} from "../view-proizvod/view-proizvod.component";

@NgModule({
  declarations: [
    ViewProizvodComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,

    RouterModule.forRoot([
    ])
  ],
  providers: [SharedDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
