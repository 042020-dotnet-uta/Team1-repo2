import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
    selector: 'app-view-cookbook',
    templateUrl: './view-cookbook.component.html',
    styleUrls: ['./view-cookbook.component.css']
})
/** ViewCookbook component*/
export class ViewCookbookComponent {
    /** ViewCookbook ctor */
  constructor(private location: Location) {

  }
  goBack(): void {
    this.location.back();
  };
}
