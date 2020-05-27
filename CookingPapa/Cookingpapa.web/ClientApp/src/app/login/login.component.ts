import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
/** Login component*/
export class LoginComponent {
  /** Login ctor */
  constructor(private location: Location) {

  }
  goBack(): void {
    this.location.back();
  };
}
