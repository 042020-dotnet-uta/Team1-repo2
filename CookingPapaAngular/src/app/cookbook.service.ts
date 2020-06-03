import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

import { AuthService } from './auth.service';
import { CookbookResponse } from './Models/cookbook-response';

@Injectable({
  providedIn: 'root'
})
export class CookbookService {

  constructor(private http: HttpClient,
    public auth: AuthService) { }
      currentUser;
      ID : number;
      cookbookUrl: string = /*environment.cookingPapaUrl + 'Cookbooks/';*/'http://localhost:64480/api/Cookbooks/';
      
  ngOnInit(): void {
    this.auth.userProfile$.subscribe(data => {
      this.currentUser = data;
      this.ID = <number> + this.currentUser.sub.toString().substr(6);
    });
  }
  
  getCookbookRecipes() {
    //Temp for testing
    this.ID = 1;
     return this.http.get<CookbookResponse[]>(this.cookbookUrl + this.ID).toPromise()
       .then(recipe => recipe);
  }
  removeRecipe(Id: number){
    return this.http.delete<CookbookResponse>(this.cookbookUrl + Id).subscribe();
  }
}
