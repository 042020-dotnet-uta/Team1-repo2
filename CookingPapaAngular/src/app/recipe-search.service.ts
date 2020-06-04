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
  recipesUrl = 'https://cookingpapa.azurewebsites.net/api/Recipes';
  
  getRecipes(searchTerm: string) {
     return this.http.get<RecipeVM[]>(this.recipesUrl + "?searchPattern="+searchTerm).toPromise()
       .then(recipe => recipe);
  }
}
