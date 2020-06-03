import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { RecipeInformationsVM } from '../Models/recipeInformationsVM';
import { RecipeIngredientGroupVM } from '../Models/RecipeIngredientGroupVM';
import { RecipeInformationReviewVM } from '../Models/recipeInformationReviewVM';
import { PostRecipeVM } from '../Models/postRecipeVM';
import { GetIngOriMeaInformation } from '../Models/getIngOriMeaInformation';
import { RecipeDetailService } from '../services/recipe-detail.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../auth.service';


@Component({
  selector: 'app-edit-recipe',
  templateUrl: './edit-recipe.component.html',
  styleUrls: ['./edit-recipe.component.css']
})
export class EditRecipeComponent implements OnInit {

  public newRecipe:PostRecipeVM={
    RecipeId:0,
    UserId:1,
    RecipeOriginName:"",
    RecipeName:"",
    RecipeCookTime:0,
    RecipeInstruction:"",
    RecipeIngredientGroupVM:[]
  }
  public information:GetIngOriMeaInformation={
    origins:[],
    ingredients:[],
    measurementUnits:[]
  };
  public newRecipeIngredientGroup:RecipeIngredientGroupVM[]=[];
  //Functions
  addIngredient(newIngredient:string){
    if(newIngredient){
      this.information.ingredients.push(newIngredient);
    }
  }
  addOrigin(newOrigin:string){
    if(newOrigin){
      this.information.origins.push(newOrigin);    
    }
  }
  addMeasurement(newMeasurement:string){
    if(newMeasurement){
      this.information.measurementUnits.push(newMeasurement);
    }
  }
  addIngredientGroup(selectedIngredient:string,
    selectedAmount:number,selectedMeasure:string){
      this.newRecipeIngredientGroup.push({
        ingredientName:selectedIngredient,
        ingredientAmount:selectedAmount,
        measurementName:selectedMeasure
      }
      )
    }
  removeIngredient(ingredient){
    this.newRecipeIngredientGroup
    .splice(this.newRecipeIngredientGroup.indexOf(ingredient),1);
  }
  getInformation():void{
    this.recServ.getIngOriMeaInformation().subscribe(g=>{
        this.information.ingredients = g.ingredients;
        this.information.measurementUnits = g.measurementUnits;
        this.information.origins = g.origins;
      console.log(g)});
  }
  goBack():void{
    this.location.back();
  }
  getRecipe():void{
    const x=+this.route.snapshot.paramMap.get('id');
    this.recServ.getRecipe(x).subscribe(g=>{
      this.newRecipe.RecipeId = g.recipeId,
      this.newRecipe.RecipeOriginName = g.recipeOrigin,
      this.newRecipe.RecipeName = g.recipeName,
      this.newRecipe.RecipeCookTime = g.recipeCooktime,
      this.newRecipe.RecipeInstruction = g.recipeDescription,
      this.newRecipeIngredientGroup = g.recipeIngredientGroupVMs;
      console.log(this.newRecipeIngredientGroup)});
  }

  onEdit():void{
      this.newRecipe.RecipeIngredientGroupVM = this.newRecipeIngredientGroup;
      //this.auth.userProfile$.subscribe(g=>this.newRecipe.UserId=<number> + g.sub.toString().substr(6));
      console.log(this.newRecipe);
      this.recServ.putRecipe(this.newRecipe).subscribe(
        success=>console.log('success: ', success),
        error=>console.log('error')
      );      
  }

  constructor(private location:Location,
    private recServ:RecipeDetailService,
    private route: ActivatedRoute,
    private auth:AuthService) { }

  ngOnInit(): void {
    this.getRecipe();
    this.getInformation();
  }

}
