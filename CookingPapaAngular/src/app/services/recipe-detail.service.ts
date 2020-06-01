import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RecipeInformationsVM } from '../Models/recipeInformationsVM'
import { GetRecipesVM } from '../Models/GetRecipesVM';
import { UserVM } from '../Models/userVM';


@Injectable({
  providedIn:'root'
})
export class RecipeDetailService {
  constructor(private http: HttpClient) { }

getRecipe(x:number){
  return this.http.get<RecipeInformationsVM>(`https://cors-anywhere.herokuapp.com/https://cookingpapa.azurewebsites.net/api/recipes/4`)
}
}
