import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { PostRecipeVM } from '../Models/postRecipeVM';
import { RecipeDetailService } from '../services/recipe-detail.service'
import { GetIngOriMeaInformation } from '../Models/getIngOriMeaInformation';
import { RecipeIngredientGroupVM } from '../Models/RecipeIngredientGroupVM';
import { AuthService } from '../auth.service';
import { CookBookVM } from '../Models/cookBookVM';



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
  public err1:boolean;
  public err2:boolean;
  public err3:boolean;

  //Functions
  addIngredient(newIngredient:string){
    if(!this.information.ingredients.find(x=>
      x.toLowerCase()==newIngredient.toLowerCase())){
      this.information.ingredients.push(newIngredient);
    }else{
      this.err2 = true;
    }
  }

  addOrigin(newOrigin:string){
    if(!this.information.origins.find(x=>
      x.toLowerCase()==newOrigin.toLowerCase())){
      this.information.origins.push(newOrigin);    
    }else{
      this.err1=true;
    }
  }

  addMeasurement(newMeasurement:string){
    if(!this.information.measurementUnits.find(x=>
      x.toLowerCase()==newMeasurement.toLowerCase())){
      this.information.measurementUnits.push(newMeasurement);
    }else{
      this.err3 = true;
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
  // addToCookbook():void{
  //   this.newCookbook={
  //     userId:this.newRecipe.UserId,
  //     recipeId:this.newRecipe.RecipeId};
  //     console.log(this.newCookbook);
  //     this.recServ.postCookbook(this.newCookbook).subscribe(
  //       success=>console.log('success: ',success),
  //       error=>console.log('error')
  //       );
  //   }

  onCreate(){
    this.newRecipe.RecipeIngredientGroupVM = this.newRecipeIngredientGroup;
    this.auth.userProfile$.subscribe(g=>this.newRecipe.UserId=<number> + g.sub.toString().substr(6));
    console.log(this.newRecipe);
    this.recServ.postRecipe(this.newRecipe).subscribe(g=>{
      this.newRecipe.RecipeId=g.RecipeId;
    }   
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
