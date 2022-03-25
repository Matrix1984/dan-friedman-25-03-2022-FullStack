import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SubSink } from 'subsink';
import { City } from '../dtos/city.type';
import { FavouriteService } from '../services/favourite.service';

@Component({
  selector: 'app-favourites',
  templateUrl: './favourites.component.html',
  styleUrls: ['./favourites.component.css']
})
export class FavouritesComponent implements OnInit, OnDestroy {

  private subs = new SubSink();

  cities: City[] = [];

  constructor(private http: HttpClient,
    private favService: FavouriteService) { }

  ngOnInit(): void {
    this.subs.add(this.http.get<City[]>(`${environment.apiUrl}City/ListFavCities`)
      .subscribe({
        error: (err) => {
          console.log(err)
        },
        next: (res) => {
          this.cities = res;
        }
      }));
  }

  onRemoveFavoriteClick(cityId: number) {
    this.subs.add(this.favService.modifyFavorite(cityId, false).subscribe({
      error: (err) => {
        console.log(err)
      },
      next: (res) => {
        this.cities= this.cities.filter(x=>x.cityId!==cityId);
      }
    }));
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }
}
