import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import {RecipeDetailService} from '../services/recipe-detail.service';
import { RecipeInformationsVM } from '../Models/recipeInformationsVM'
import { GetRecipesVM } from '../Models/GetRecipesVM';
import { UserVM } from '../Models/userVM';
import { RecipeIngredientGroupVM } from '../Models/RecipeIngredientGroupVM';
import { RecipeInformationReviewVM } from '../Models/recipeInformationReviewVM';

@Component({
  selector: 'app-view-recipe',
  templateUrl: './view-recipe.component.html',
  styleUrls: ['./view-recipe.component.css']
})
export class ViewRecipeComponent implements OnInit {
  //public test:RecipeInformationsVM;
  public test:RecipeInformationsVM;
  public test2:RecipeIngredientGroupVM[];
  public test3:RecipeInformationReviewVM[];
  
  constructor(private location: Location, private recServ:RecipeDetailService) { }

  goBack():void{
  this.location.back();
};

  ngOnInit(): void { }

  getRecipe(x:number){
    this.recServ.getRecipe(x).subscribe(g=>{
      this.test = g;
      this.test2 = g.recipeIngredientGroupVMs;
      this.test3 = g.recipeReviewVMs;
      console.log(g)});
  }
}
