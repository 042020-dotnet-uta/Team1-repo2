import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
    selector: 'app-user-access',
    templateUrl: './user-access.component.html',
    styleUrls: ['./user-access.component.css']
})
/** UserAccess component*/
export class UserAccessComponent implements OnInit{
    /** UserAccess ctor */
  constructor(private location: Location) {

    }
  goBack(): void {
    this.location.back();
  };
  ngOnInit(): void {
  }
}
