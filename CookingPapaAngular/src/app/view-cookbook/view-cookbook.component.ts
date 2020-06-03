import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { AuthService } from '../auth.service';

import { CookbookService } from '../cookbook.service';
import { CookbookResponse } from '../Models/cookbook-response';

@Component({
  selector: 'app-view-cookbook',
  templateUrl: './view-cookbook.component.html',
  styleUrls: ['./view-cookbook.component.css']
})
export class ViewCookbookComponent implements OnInit {
  recipes: CookbookResponse[];

  constructor(private location:Location,
              private cookBook: CookbookService){}

  delete(entry: CookbookResponse) : void{
    this.recipes = this.recipes.filter(r => r !==entry);
    this.cookBook.removeRecipe(entry.cookbookId);//.subscribe();
  }

  goBack():void{
    this.location.back();
  }
  ngOnInit(): void {
    this.cookBook.getCookbookRecipes()
      .then(recipes => this.recipes = recipes);
  }
}
