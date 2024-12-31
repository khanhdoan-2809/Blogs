import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations:[],
  imports: [
    RouterModule,
    HttpClientModule
  ],
  exports: [
    BrowserModule,
    RouterModule,
  ],
  providers: [],
})
export class AppModule { }