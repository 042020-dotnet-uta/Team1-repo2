import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {AppRoutingModule} from './app-routing.module';
import {NavMenuComponent}from './nav-menu/nav-menu.component';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserAccessComponent } from './user-access/user-access.component';
import { CreateRecipeComponent } from './create-recipe/create-recipe.component';
import { EditRecipeComponent } from './edit-recipe/edit-recipe.component';
import { ViewRecipeComponent } from './view-recipe/view-recipe.component';
import { SearchRecipeComponent } from './search-recipe/search-recipe.component';
import { ViewCookbookComponent } from './view-cookbook/view-cookbook.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    RegisterComponent,
    UserAccessComponent,
    CreateRecipeComponent,
    EditRecipeComponent,
    ViewRecipeComponent,
    SearchRecipeComponent,
    ViewCookbookComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }