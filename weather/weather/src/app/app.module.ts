import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';
import { FavouritesComponent } from './favourites/favourites.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    FavouritesComponent
  ],
  imports: [
    CommonModule,  
    FormsModule , 
    BrowserModule,
     HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: MainComponent, pathMatch: 'full' }, 
      { path: 'fav', component: FavouritesComponent },  
      { path: '**', component: MainComponent }
     ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
 