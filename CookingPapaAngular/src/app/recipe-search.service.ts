import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

import { RecipeVM } from './Models/recipeVM';

@Injectable({
  providedIn: 'root'
})
export class RecipeSearchService {
  /*
     recipes : string[] = [
      'Good Food',
      'Gross Food',
      'Some Food',
      'Some More Food',
      'Eat it Damnit',
      'Sure why not'
    ];
    */
  constructor(private http: HttpClient) { }

  getRecipes(searchTerm: string) {
    const url : string = 'https://cors-anywhere.herokuapp.com/' + environment.recipesUrl;

     return this.http.get<RecipeVM[]>(environment.recipesUrl).toPromise()
       .then(recipe => recipe);
    //return this.recipes;
  }
}
