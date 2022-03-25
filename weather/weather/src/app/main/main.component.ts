import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SubSink } from 'subsink';
import { City } from '../dtos/city.type';
import { LocationSearchResponse } from '../dtos/location-search-response.type';
import { FavouriteService } from '../services/favourite.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit,OnDestroy {

  private subs = new SubSink();
  
  locations: LocationSearchResponse[] = [];

  locationName:string | undefined;
  
  formError:string | undefined;
  
  selectedLocationWeatherData: City| undefined; 

  constructor(private http: HttpClient,
    private favService :FavouriteService ) { }

  ngOnInit(): void {
  }

  onSubmit() {
    if(!this.locationName){
      this.formError="Locaiton name cant be empty";
      return;
    }

    this.subs.add(this.http.get<LocationSearchResponse[]>(`${environment.apiUrl}City?searchCity=`+this.locationName)
      .subscribe({
        error: (err) => {
          console.log(err)
        },
        next: (res) => {
          this.locations = res;
        }
      }));
  }
 
  onSelectCityClick(cityKey:string, cityName:string ){
    this.subs.add(this.http.get<City>(`${environment.apiUrl}Weather?cityKey=`+cityKey+`&cityName=`+cityName)
      .subscribe({
        error: (err) => {
          console.log(err)
        },
        next: (res) => {
          this.selectedLocationWeatherData = res;
        }
      }));
  }

  onFavoriteClick(cityId:number ){
    this.subs.add(this.favService.modifyFavorite(cityId,true).subscribe({
      error: (err) => {
        console.log(err)
      },
      next: (res) => { 
      }
    }));
  }
  
  ngOnDestroy() {
    this.subs.unsubscribe();
  }
}
