import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { RecipeInformationsVM } from '../Models/recipeInformationsVM';
import { RecipeIngredientGroupVM } from '../Models/RecipeIngredientGroupVM';
import { RecipeInformationReviewVM } from '../Models/recipeInformationReviewVM';
import { PostRecipeVM } from '../Models/postRecipeVM';
import { GetIngOriMeaInformation } from '../Models/getIngOriMeaInformation';
import { RecipeDetailService } from '../services/recipe-detail.service';
import { ActivatedRoute, Router } from '@angular/router';
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

  popUp(){
    confirm("You're Recipe has been editted!");
    this.router.navigateByUrl('/search-recipe');
  }

  onEdit():void{
      this.newRecipe.RecipeIngredientGroupVM = this.newRecipeIngredientGroup;
      this.auth.userProfile$.subscribe(g=>this.newRecipe.UserId=<number> + g.sub.toString().substr(6));
      console.log(this.newRecipe);
      this.recServ.putRecipe(this.newRecipe).subscribe(
        success=>console.log('success: ', success),
        error=>console.log('error')
      );
      this.popUp();      
  }

  constructor(private location:Location,
    private recServ:RecipeDetailService,
    private route: ActivatedRoute,
    private auth:AuthService,
    private router:Router) { }

  ngOnInit(): void {
    this.getRecipe();
    this.getInformation();
  }

}
