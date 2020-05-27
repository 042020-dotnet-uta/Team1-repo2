import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
    selector: 'app-user-access',
    templateUrl: './user-access.component.html',
    styleUrls: ['./user-access.component.css']
})
/** UserAccess component*/
export class UserAccessComponent {
    /** UserAccess ctor */
  constructor(private location: Location) {

    }
  goBack(): void {
    this.location.back();
  };
}
