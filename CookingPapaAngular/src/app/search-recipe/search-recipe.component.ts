import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-search-recipe',
  templateUrl: './search-recipe.component.html',
  styleUrls: ['./search-recipe.component.css']
})
export class SearchRecipeComponent implements OnInit {

  constructor(private location: Location) { }

  goBack():void{
    this.location.back();
  }
  ngOnInit(): void {
  }

}
