import { HttpClient } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment'; 
 
@Injectable({ providedIn: 'root' })
export class FavouriteService { 

  constructor( 
    private http: HttpClient
  ) {
  }

  modifyFavorite(cityId:number, isFavourite:Boolean) : Observable<unknown> {
    return this.http.patch<unknown>(`${environment.apiUrl}City?cityId=` +cityId,{ isFavourite:isFavourite });
  }
 
}
