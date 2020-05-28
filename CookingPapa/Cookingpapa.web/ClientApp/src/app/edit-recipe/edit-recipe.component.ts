import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
    selector: 'app-edit-recipe',
    templateUrl: './edit-recipe.component.html',
    styleUrls: ['./edit-recipe.component.css']
})
/** EditRecipe component*/
export class EditRecipeComponent {
    /** EditRecipe ctor */
  constructor(private location: Location) {

  }
  goBack(): void {
    this.location.back();
  };
}
