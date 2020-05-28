import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
    selector: 'app-search-recipe',
    templateUrl: './search-recipe.component.html',
    styleUrls: ['./search-recipe.component.css']
})
/** SearchRecipe component*/
export class SearchRecipeComponent {
    /** SearchRecipe ctor */
  constructor(private location: Location) {

  }
  goBack(): void {
    this.location.back();
  };
}
