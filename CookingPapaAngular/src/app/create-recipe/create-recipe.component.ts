import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { PostRecipeVM } from '../Models/postRecipeVM';
import { RecipeDetailService } from '../services/recipe-detail.service'
import { GetIngOriMeaInformation } from '../Models/getIngOriMeaInformation';
import { RecipeIngredientGroupVM } from '../Models/RecipeIngredientGroupVM';
import { AuthService } from '../auth.service';
import { CookBookVM } from '../Models/cookBookVM';
import { Router } from '@angular/router';
import { isNull, isNullOrUndefined } from 'util';



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
  public newCookbook:CookBookVM={userId:0,recipeId:0};
  err1:boolean; err2:boolean; err3:boolean;
  hideBut1:boolean; hideBut2:boolean; hideBut3:boolean;
  //Functions

  isNullOrWhitespace(input:string) {
    if (typeof input === 'undefined' || input == null) return true;
    return input.replace(/\s/g, '').length < 1;
}
  hidingButton1(){
    if(this.hideBut1){return this.hideBut1=false}
    this.hideBut1=true;
  }
  hidingButton2(){
    if(this.hideBut2){return this.hideBut2=false}
    this.hideBut2=true;
  }
  hidingButton3(){
    if(this.hideBut3){return this.hideBut3=false}
    this.hideBut3=true;
  }

  addIngredient(newIngredient:string){
    if(this.information.ingredients.find(x=>
      x.toLowerCase()==newIngredient.toLowerCase())||this.isNullOrWhitespace(newIngredient)){
        this.err2 = true;
    }
    else{
      this.information.ingredients.push(newIngredient);
    }
  }

  addOrigin(newOrigin:string){
    if(this.information.origins.find(x=>
      x.toLowerCase()==newOrigin.toLowerCase())||this.isNullOrWhitespace(newOrigin)){
        this.err1=true; 
    }else{
      this.information.origins.push(newOrigin);
      
    }
  }

  addMeasurement(newMeasurement:string){
    if(this.information.measurementUnits.find(x=>
      x.toLowerCase()==newMeasurement.toLowerCase())||this.isNullOrWhitespace(newMeasurement)){
        this.err3 = true;
    }else{
      this.information.measurementUnits.push(newMeasurement)     
    }
  }

  addIngredientGroup(selectedIngredient:string,
    selectedAmount:number,selectedMeasure:string){
      if(!this.isNullOrWhitespace(selectedAmount.toString())){
      this.newRecipeIngredientGroup.push({
        ingredientName:selectedIngredient,
        ingredientAmount:selectedAmount,
        measurementName:selectedMeasure
      }
      )}
      console.log(this.newRecipeIngredientGroup);
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
    this.recServ.postRecipe(this.newRecipe).subscribe(g=>{
      this.newRecipe.RecipeId=g.RecipeId;
    });          
    confirm("Success! Recipe has been created.");
    this.router.navigateByUrl(`/view-recipe/${<number>this.newRecipe.RecipeId}`);
  }

  goBack(): void {
    this.location.back();
  };

  //Initialization
  constructor(private location: Location,
    private recServ:RecipeDetailService,
    private auth:AuthService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.getInformation();
  }
}
