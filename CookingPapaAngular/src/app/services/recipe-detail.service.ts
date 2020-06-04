import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

import { RecipeInformationsVM } from '../Models/recipeInformationsVM'
import { GetRecipesVM } from '../Models/GetRecipesVM';
import { UserVM } from '../Models/userVM';
import { GetIngOriMeaInformation } from '../Models/getIngOriMeaInformation';
import { PostRecipeVM } from '../Models/postRecipeVM';
import { CookBookVM } from '../Models/cookBookVM';


@Injectable({
  providedIn:'root'
})
export class RecipeDetailService {
  constructor(private http: HttpClient) { }
  cookingPapaUrl = 'https://cors-anywhere.herokuapp.com/https://cookingpapa.azurewebsites.net/api/';

getRecipe(recipeId:number){
  return this.http.get<RecipeInformationsVM>(this.cookingPapaUrl + `recipes/${recipeId}`)
}
getIngOriMeaInformation(){
  return this.http.get<GetIngOriMeaInformation>(this.cookingPapaUrl + `Information`)
}
postRecipe(newRecipe:PostRecipeVM){
  return this.http.post<PostRecipeVM>(this.cookingPapaUrl + `recipes`,newRecipe)
}
putRecipe(newRecipe:PostRecipeVM){
  return this.http.put<PostRecipeVM>(this.cookingPapaUrl + `recipes`,newRecipe)
}
deleteRecipe(recipeId:number){
  return this.http.delete<number>(this.cookingPapaUrl + `recipes/${recipeId}`)
}
postCookbook(cookBook:CookBookVM){
  return this.http.post<CookBookVM>(this.cookingPapaUrl + `cookbooks`,cookBook)
}
getCookbook(userId:number){
  return this.http.get<CookBookVM[]>(this.cookingPapaUrl + `cookbooks/${userId}`)

}
}
