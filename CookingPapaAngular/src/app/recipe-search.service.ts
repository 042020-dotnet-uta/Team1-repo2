import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

import { RecipeVM } from './Models/recipeVM';

@Injectable({
  providedIn: 'root'
})
export class RecipeSearchService {
  constructor(private http: HttpClient) { }

  getRecipes(searchTerm: string) {
    const recipesUrl = 'http://localhost:64480/api/Recipes';
     return this.http.get<RecipeVM[]>(recipesUrl + "?searchPattern="+searchTerm).toPromise()
       .then(recipe => recipe);
  }
}
