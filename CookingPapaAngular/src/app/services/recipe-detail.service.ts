import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RecipeInformationsVM } from '../Models/recipeInformationsVM'
import { GetRecipesVM } from '../Models/GetRecipesVM';
import { UserVM } from '../Models/userVM';
import { GetIngOriMeaInformation } from '../Models/getIngOriMeaInformation';
import { PostRecipeVM } from '../Models/postRecipeVM';


@Injectable({
  providedIn:'root'
})
export class RecipeDetailService {
  constructor(private http: HttpClient) { }

getRecipe(x:number){
  return this.http.get<RecipeInformationsVM>(`https://cors-anywhere.herokuapp.com/https://cookingpapa.azurewebsites.net/api/recipes/${x}`)
}
getIngOriMeaInformation(){
  return this.http.get<GetIngOriMeaInformation>(`https://cors-anywhere.herokuapp.com/https://cookingpapa.azurewebsites.net/api/Information`)
}
postRecipe(newRecipe:PostRecipeVM){
  return this.http.post<PostRecipeVM>(`https://cors-anywhere.herokuapp.com/https://cookingpapa.azurewebsites.net/api/recipes`,newRecipe)
}
putRecipe(newRecipe:PostRecipeVM){
  return this.http.put<PostRecipeVM>(`https://cors-anywhere.herokuapp.com/https://cookingpapa.azurewebsites.net/api/recipes`,newRecipe)
}
}
