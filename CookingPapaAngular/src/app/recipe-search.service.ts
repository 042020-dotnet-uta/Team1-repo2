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
    const recipesUrl = 'http://localhost:64480/api/Recipes';
     return this.http.get<RecipeVM[]>(recipesUrl).toPromise()
       .then(recipe => recipe);
    //return this.recipes;
  }
}
