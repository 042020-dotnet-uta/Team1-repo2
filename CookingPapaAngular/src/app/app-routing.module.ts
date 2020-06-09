import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditRecipeComponent } from './edit-recipe/edit-recipe.component';
import { ViewRecipeComponent } from './view-recipe/view-recipe.component';
import { CreateRecipeComponent } from './create-recipe/create-recipe.component';
import { SearchRecipeComponent } from './search-recipe/search-recipe.component';
import { ViewCookbookComponent } from './view-cookbook/view-cookbook.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { AuthGuard } from './auth.guard';
import { ApiSearchComponent } from './api-search/api-search.component';


const routes: Routes = [
    {path:'', component:HomeComponent},
    {path:'edit-recipe/:id', component:EditRecipeComponent, canActivate: [AuthGuard]},
    {path:'view-recipe/:id', component:ViewRecipeComponent},
    {path:'create-recipe', component:CreateRecipeComponent, canActivate: [AuthGuard]},
    {path:'search-recipe', component:SearchRecipeComponent},
    {path:'view-cookbook', component:ViewCookbookComponent, canActivate: [AuthGuard]},
    {path: 'profile', component:ProfileComponent, canActivate: [AuthGuard]},
    {path: 'api-search', component:ApiSearchComponent}

  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }