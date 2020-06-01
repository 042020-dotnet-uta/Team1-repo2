import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
//import { Observable, Subject } from 'rxjs';
//import {
//   debounceTime, distinctUntilChanged, switchMap
// } from 'rxjs/operators';

import { RecipeSearchService } from '../recipe-search.service';

@Component({
  selector: 'app-search-recipe',
  templateUrl: './search-recipe.component.html',
  styleUrls: ['./search-recipe.component.css']
})
export class SearchRecipeComponent implements OnInit {
  recipes: string[];
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
      this.recipes = this.recipeSearchService.getRecipes(this.searchTerm);
    }
  }
  ngOnInit(): void {
  }

}
