import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

import { RecipeReviewVM } from './Models/recipeReviewVM';
import { RecipeReviewPostVM } from './Models/RecipeReviewPostVM';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {

<<<<<<< HEAD
  constructor(private http: HttpClient,
    public auth: AuthService) { }

      //currentUser;
      //ID : number;
      reviewUrl: string = environment.cookingPapaUrl + 'RecipeReviews/';/*'http://localhost:64480/api/RecipeReviews/'*/;
=======
  constructor(private http: HttpClient) { }
      reviewUrl: string = /*environment.cookingPapaUrl + 'RecipeReviews/';*/'http://localhost:64480/api/RecipeReviews/';
>>>>>>> b245266d0673e7c14e91ed098be56ee7d6fee9c9
      
      submitReview(review:RecipeReviewPostVM){
        return this.http.post<RecipeReviewVM>(this.reviewUrl, review).toPromise()
        .then(review => review);
      }
      getReviews(recipeId:number){
        return this.http.get<RecipeReviewVM[]>(this.reviewUrl + recipeId).toPromise()
       .then(reviews => reviews);
      }
}
