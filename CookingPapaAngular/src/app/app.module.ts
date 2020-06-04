import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {AppRoutingModule} from './app-routing.module';
import {NavMenuComponent}from './nav-menu/nav-menu.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { CreateRecipeComponent } from './create-recipe/create-recipe.component';
import { EditRecipeComponent } from './edit-recipe/edit-recipe.component';
import { ViewRecipeComponent } from './view-recipe/view-recipe.component';
import { SearchRecipeComponent } from './search-recipe/search-recipe.component';
import { ViewCookbookComponent } from './view-cookbook/view-cookbook.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { ApiSearchComponent } from './api-search/api-search.component';
import { RatingsComponent } from './ratings/ratings.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CreateRecipeComponent,
    EditRecipeComponent,
    ViewRecipeComponent,
    SearchRecipeComponent,
    ViewCookbookComponent,
    HomeComponent,
    ProfileComponent,
    ApiSearchComponent,
    RatingsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
