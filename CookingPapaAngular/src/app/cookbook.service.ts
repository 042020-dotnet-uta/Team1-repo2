import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

import { AuthService } from './auth.service';
import { RecipeVM } from './Models/RecipeVM';

@Injectable({
  providedIn: 'root'
})
export class CookbookService {

  constructor(private http: HttpClient,
    public auth: AuthService) { }
      currentUser;
      ID : number;

  ngOnInit(): void {
    this.auth.userProfile$.subscribe(data => {
      this.currentUser = data;
      this.ID = <number> + this.currentUser.sub.toString().substr(6);
    });
  }
  
  getCookbookRecipes() {
    //Temp for testing
    this.ID = 1;
    const cookbookUrl = 'http://localhost:64480/api/Cookbooks/';
     return this.http.get<RecipeVM[]>(cookbookUrl + this.ID).toPromise()
       .then(recipe => recipe);
  }
}
