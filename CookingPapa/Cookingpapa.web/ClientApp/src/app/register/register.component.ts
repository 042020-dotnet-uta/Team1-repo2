import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
/** Register component*/
export class RegisterComponent {
    /** Register ctor */
  constructor(private location: Location) {

  }
  goBack(): void {
    this.location.back();
  };

}
