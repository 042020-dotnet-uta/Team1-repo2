import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserAccessComponent } from './user-access/user-access.component';
import { EditRecipeComponent } from './edit-recipe/edit-recipe.component';
import { ViewRecipeComponent } from './view-recipe/view-recipe.component';
import { CreateRecipeComponent } from './create-recipe/create-recipe.component';
import { SearchRecipeComponent } from './search-recipe/search-recipe.component';
import { ViewCookbookComponent } from './view-cookbook/view-cookbook.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';


const routes: Routes = [
    {path:'', component:HomeComponent},
    {path:'login', component:LoginComponent},
    {path:'register', component:RegisterComponent},
    {path:'user-access', component:UserAccessComponent},
    {path:'edit-recipe', component:EditRecipeComponent},
    {path:'view-recipe', component:ViewRecipeComponent},
    {path:'create-recipe', component:CreateRecipeComponent},
    {path:'search-recipe', component:SearchRecipeComponent},
    {path:'view-cookbook', component:ViewCookbookComponent},
    {path: 'profile', component:ProfileComponent}

  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }