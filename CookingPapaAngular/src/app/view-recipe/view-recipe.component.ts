import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import {RecipeDetailService} from '../services/recipe-detail.service';
import { RecipeInformationsVM } from '../Models/recipeInformationsVM'
import { RecipeIngredientGroupVM } from '../Models/RecipeIngredientGroupVM';
import { RecipeInformationReviewVM } from '../Models/recipeInformationReviewVM';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../auth.service';
import { CookBookVM } from '../Models/cookBookVM';
import { CompileShallowModuleMetadata } from '@angular/compiler';

@Component({
  selector: 'app-view-recipe',
  templateUrl: './view-recipe.component.html',
  styleUrls: ['./view-recipe.component.css']
})
export class ViewRecipeComponent implements OnInit {

  public test:RecipeInformationsVM;
  public test2:RecipeIngredientGroupVM[];
  public test3:RecipeInformationReviewVM[];
  public recipeCreatorId:number=1; 
  public userLoggedId:number=6;
  public notGuest:boolean=false;
  public ownRecipe:boolean=false;
  public inCookbook:boolean=false;
  public newCookbook:CookBookVM={userId:0,recipeId:0};
  public userCookbooks:CookBookVM[]=[];
  
  goBack():void{
  this.location.back();
};
  getRecipe():void{
    const x=+this.route.snapshot.paramMap.get('id');
    this.recServ.getRecipe(x).subscribe(g=>{
      this.test = g;
      this.test2 = g.recipeIngredientGroupVMs;
      this.test3 = g.recipeReviewVMs;
      this.recipeCreatorId = g.recipeCreatorId;
      console.log(g);
      //shows edit/delete/cookbook button only if user is logged in
      if(this.auth.loggedIn)
      {
        this.getUserId();
        this.getUserCookbooks();
        this.notGuest = true;
        //check if the accessing user created this recipe or not
        if(this.recipeCreatorId==this.userLoggedId)this.ownRecipe=true;  
     }});}
  



    onDelete():void{
      this.recServ.deleteRecipe(this.test.recipeId).subscribe(
        success=>console.log('success: ',success),
        error=>console.log('error')
      );
      confirm("You've deleted the recipe!");
      this.goBack();
    }

    addToCookbook():void{
      this.newCookbook={
        userId:this.userLoggedId,
        recipeId:this.test.recipeId};
        console.log(this.newCookbook);
      this.recServ.postCookbook(this.newCookbook).subscribe(x=>{
        this.userCookbooks.push(x);
          this.inCookbook=true;
          console.log('added and checked')  
          confirm("Recipe has been added to your cookbook!");    
      });
      };
           
     getUserId():void{
      this.auth.userProfile$.subscribe(g=>this.userLoggedId=<number> + g.sub.toString().substr(6));
      console.log(this.userLoggedId);
     }

     getUserCookbooks():void{
        this.recServ.getCookbook(this.userLoggedId).subscribe(g=>{
          this.userCookbooks=g;
          console.log(this.userCookbooks);
          if(this.userCookbooks.find(x=>x.recipeId==this.test.recipeId)){
            this.inCookbook=true;
            console.log("found!")
          }  
        })
     }
  
     constructor(private route: ActivatedRoute,
      private location: Location, 
      private recServ:RecipeDetailService,
      private auth:AuthService) { }

      ngOnInit(): void { 
        this.getRecipe();
      }
}
