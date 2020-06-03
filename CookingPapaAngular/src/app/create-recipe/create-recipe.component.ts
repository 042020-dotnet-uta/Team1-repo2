import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { PostRecipeVM } from '../Models/postRecipeVM';
import { RecipeDetailService } from '../services/recipe-detail.service'
import { GetIngOriMeaInformation } from '../Models/getIngOriMeaInformation';
import { RecipeIngredientGroupVM } from '../Models/RecipeIngredientGroupVM';
import { AuthService } from '../auth.service';


@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.css']
})
export class CreateRecipeComponent implements OnInit {
  //Properties
  public newRecipe:PostRecipeVM={
    RecipeId:0,
    UserId:5,
    RecipeOriginName:"",
    RecipeName:"",
    RecipeCookTime:null,
    RecipeInstruction:"",
    RecipeIngredientGroupVM:[]
  };
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
  onCreate(){
    this.newRecipe.RecipeIngredientGroupVM = this.newRecipeIngredientGroup;
    this.auth.userProfile$.subscribe(g=>this.newRecipe.UserId=<number> + g.sub.toString().substr(6));
    console.log(this.newRecipe);
    this.recServ.postRecipe(this.newRecipe).subscribe(
      success=>console.log('success: ', success),
      error=>console.log('error')
    );  
  }

  goBack(): void {
    this.location.back();
  };
  //Initialization
  constructor(private location: Location,
    private recServ:RecipeDetailService,
    private auth:AuthService) {
  }

  ngOnInit(): void {
    this.getInformation();
  }
}
