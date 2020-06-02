import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import {RecipeDetailService} from '../services/recipe-detail.service';
import { RecipeInformationsVM } from '../Models/recipeInformationsVM'
import { RecipeIngredientGroupVM } from '../Models/RecipeIngredientGroupVM';
import { RecipeInformationReviewVM } from '../Models/recipeInformationReviewVM';
import { ActivatedRoute } from '@angular/router';

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
  
  constructor(private route: ActivatedRoute, private location: Location, private recServ:RecipeDetailService) { }

  goBack():void{
  this.location.back();
};

  ngOnInit(): void { 
    this.getRecipe();
  }

  getRecipe():void{
    const x=+this.route.snapshot.paramMap.get('id');
    this.recServ.getRecipe(x).subscribe(g=>{
      this.test = g;
      this.test2 = g.recipeIngredientGroupVMs;
      this.test3 = g.recipeReviewVMs;
      console.log(g)});
  }
}
