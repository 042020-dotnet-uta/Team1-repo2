import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { PostRecipeVM } from '../Models/postRecipeVM';
import { RecipeDetailService } from '../services/recipe-detail.service'
import { GetIngOriMeaInformation } from '../Models/getIngOriMeaInformation';

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.css']
})
export class CreateRecipeComponent implements OnInit {
  public newRecipe:PostRecipeVM;
  public information:GetIngOriMeaInformation;
  constructor(private location: Location,private recServ:RecipeDetailService) {
   }
   

  goBack(): void {
    this.location.back();
  };
  getInformation():void{
    //const x=+this.route.snapshot.paramMap.get('id');
    this.recServ.getIngOriMeaInformation().subscribe(g=>{
        this.information.Ingredients = g.Ingredients;
        this.information.MeasurementUnits = g.MeasurementUnits;
        this.information.Origins = g.Origins;
      console.log(g)});

  }
  ngOnInit(): void {
  }

}
