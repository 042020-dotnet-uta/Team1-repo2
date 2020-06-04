import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Observable, Subject } from 'rxjs';

import { RecipeSearchService } from '../recipe-search.service';
import { RecipeVM } from '../Models/recipeVM';
import { AbstractExtendedWebDriver } from 'protractor/built/browser';

@Component({
  selector: 'app-search-recipe',
  templateUrl: './search-recipe.component.html',
  styleUrls: ['./search-recipe.component.css']
})
export class SearchRecipeComponent implements OnInit {
  allRecipes: RecipeVM[];
  recipes: RecipeVM[];
  searchTerm: string;
  newrec:RecipeVM;

  constructor(private location: Location,
    private recipeSearchService: RecipeSearchService) { }

  goBack(): void {
    this.location.back();
  }
  search(searchTerm: string): void {
    this.searchTerm = searchTerm;

    this.recipes = this.allRecipes.filter(r => r.recipeName.toLowerCase().includes(searchTerm.toLowerCase()));
  }
  private loadRecipes(){
    this.searchTerm = "";
    console.log("Loading Recipes...")
      this.recipeSearchService.getRecipes(this.searchTerm)
        .then(recipes => {
          this.recipes = this.allRecipes = recipes
        });
    console.log("Recipes Loaded...")
  }
  ngOnInit(): void {
    console.log('ngOnInit Started...');
    this.loadRecipes();
        console.log('allRecipes = {}', this.allRecipes);
        console.log('recipes = {}', this.recipes);
        console.log('ngOnInit Finished...');
  }
}
