import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { AuthService } from '../auth.service';

import { CookbookService } from '../cookbook.service';
import { RecipeVM } from '../Models/RecipeVM';

@Component({
  selector: 'app-view-cookbook',
  templateUrl: './view-cookbook.component.html',
  styleUrls: ['./view-cookbook.component.css']
})
export class ViewCookbookComponent implements OnInit {
  recipes: RecipeVM[];

  constructor(private location:Location,
              private cookBook: CookbookService){}

  goBack():void{
    this.location.back();
  }
  ngOnInit(): void {
    this.cookBook.getCookbookRecipes()
      .then(recipes => this.recipes = recipes);
  }
}
