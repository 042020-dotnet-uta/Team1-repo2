import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Observable, Subject } from 'rxjs';
//import {
//   debounceTime, distinctUntilChanged, switchMap
// } from 'rxjs/operators';

import { RecipeSearchService } from '../recipe-search.service';
import { RecipeVM } from '../Models/recipeVM';
import { AbstractExtendedWebDriver } from 'protractor/built/browser';

@Component({
  selector: 'app-search-recipe',
  templateUrl: './search-recipe.component.html',
  styleUrls: ['./search-recipe.component.css']
})
export class SearchRecipeComponent implements OnInit {
  recipes: RecipeVM[];
  searchTerm: string;

  constructor(private location: Location,
    private recipeSearchService: RecipeSearchService) { }

  goBack(): void {
    this.location.back();
  }
  search(searchTerm: string): void {
    this.searchTerm = searchTerm;
    if (searchTerm.length === 0) {
      this.recipes = null;
    }
    else {
      this.recipeSearchService.getRecipes(this.searchTerm)
        .then(recipes => this.recipes = recipes);
    }
  }
  ngOnInit(): void {
  }
}
