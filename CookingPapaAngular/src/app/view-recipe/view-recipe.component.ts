import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import {RecipeDetailService} from '../services/recipe-detail.service';
import { RecipeInformationsVM } from '../Models/recipeInformationsVM'
import { RecipeIngredientGroupVM } from '../Models/RecipeIngredientGroupVM';
import { RecipeInformationReviewVM } from '../Models/recipeInformationReviewVM';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../auth.service';

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
  public currentUserId:number=0; 
  public userLoggedId:number=1;
  public ownRecipe:boolean=false;

  constructor(private route: ActivatedRoute,
     private location: Location, 
     private recServ:RecipeDetailService,
     private auth:AuthService) { }

  goBack():void{
  this.location.back();
};

  ngOnInit(): void { 
    this.getUserId();
    this.getRecipe();
  }

  getRecipe():void{
    const x=+this.route.snapshot.paramMap.get('id');
    this.recServ.getRecipe(x).subscribe(g=>{
      this.test = g;
      this.test2 = g.recipeIngredientGroupVMs;
      this.test3 = g.recipeReviewVMs;
      this.currentUserId = g.recipeCreatorId;
      console.log(g);
      if(this.currentUserId==this.userLoggedId)this.ownRecipe=true;});
    }
      //check if the accessing user created this recipe or not
           
     getUserId():void{
      this.auth.userProfile$.subscribe(g=>this.userLoggedId=<number> + g.sub.toString().substr(6));
      console.log(this.userLoggedId);
     }
  
    
  checkCookbook():void{

  }
}
