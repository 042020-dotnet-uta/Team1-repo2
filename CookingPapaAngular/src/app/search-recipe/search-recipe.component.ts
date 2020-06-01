import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { environment } from 'src/environments/environment';

import { RecipeSearchService } from '../recipe-search.service';

@Component({
  selector: 'app-search-recipe',
  templateUrl: './search-recipe.component.html',
  styleUrls: ['./search-recipe.component.css']
})
export class SearchRecipeComponent implements OnInit {

  constructor(private location: Location,
              private recipeSearchService: RecipeSearchService) { }

  goBack():void{
    this.location.back();
  }
  ngOnInit(): void {
  }
}
