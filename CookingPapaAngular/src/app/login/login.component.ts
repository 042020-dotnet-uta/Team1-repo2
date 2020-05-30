import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
/** Login component*/
export class LoginComponent implements OnInit{
  /** Login ctor */
  constructor(private location: Location) {
  }
  goBack(): void {
    this.location.back();
  };


  ngOnInit(): void {
  }
}
