import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
    selector: 'app-view-recipe',
    templateUrl: './view-recipe.component.html',
    styleUrls: ['./view-recipe.component.css']
})
/** view-recipe component*/
export class ViewRecipeComponent {
    /** view-recipe ctor */
  constructor(private location: Location) {

  }
  goBack(): void {
    this.location.back();
  };
}
