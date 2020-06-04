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
JDLocalUrl = 'http://localhost:64480/api/';
getRecipe(recipeId:number){
  return this.http.get<RecipeInformationsVM>(/*environment.cookingPapaUrl*/ this.JDLocalUrl + `recipes/${recipeId}`)
}
getIngOriMeaInformation(){
  return this.http.get<GetIngOriMeaInformation>(/*environment.cookingPapaUrl*/ this.JDLocalUrl + `Information`)
}
postRecipe(newRecipe:PostRecipeVM){
  return this.http.post<PostRecipeVM>('https://cors-anywhere.herokuapp.com/https://cookingpapa.azurewebsites.net/api/'/*environment.cookingPapaUrl this.JDLocalUrl*/ + `recipes`,newRecipe)
}
putRecipe(newRecipe:PostRecipeVM){
  return this.http.put<PostRecipeVM>('https://cors-anywhere.herokuapp.com/https://cookingpapa.azurewebsites.net/api/'/*environment.cookingPapaUrl*/ + `recipes`,newRecipe)
}
deleteRecipe(recipeId:number){
  return this.http.delete<number>(/*environment.cookingPapaUrl*/ this.JDLocalUrl + `recipes/${recipeId}`)
}
postCookbook(cookBook:CookBookVM){
  return this.http.post<CookBookVM>(/*'https://cors-anywhere.herokuapp.com/https://cookingpapa.azurewebsites.net/api/'*/ this.JDLocalUrl + `cookbooks`,cookBook)
}
getCookbook(userId:number){
  return this.http.get<CookBookVM[]>(/*'https://cors-anywhere.herokuapp.com/https://cookingpapa.azurewebsites.net/api/'*/ this.JDLocalUrl + `cookbooks/${userId}`)

}
}
