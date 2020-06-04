import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

import { AuthService } from './auth.service';
import { RecipeReviewVM } from './Models/recipeReviewVM';

@Injectable({
  providedIn: 'root'
})
export class ReviewServcieService {

  constructor(private http: HttpClient,
    public auth: AuthService) { }

      currentUser;
      ID : number;
      reviewUrl: string = environment.cookingPapaUrl + 'RecipeReviews/';/*'http://localhost:64480/api/RecipeReviews/'*/;
      
      submitReview(review:RecipeReviewVM){
        this.ID = 1;
        return this.http.post<RecipeReviewVM>(this.reviewUrl, review).toPromise()
        .then(recipe => recipe);
      }
}
