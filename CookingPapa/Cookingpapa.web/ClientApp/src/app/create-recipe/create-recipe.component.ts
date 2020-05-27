import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
    selector: 'app-create-recipe',
    templateUrl: './create-recipe.component.html',
    styleUrls: ['./create-recipe.component.css']
})
/** CreateRecipe component*/
export class CreateRecipeComponent {
    /** CreateRecipe ctor */
  constructor(private location: Location) {

  }
  goBack(): void {
    this.location.back();
  };
}
