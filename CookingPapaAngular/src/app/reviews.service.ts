import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

import { RecipeReviewVM } from './Models/recipeReviewVM';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {

  constructor(private http: HttpClient) { }
      reviewUrl: string = /*environment.cookingPapaUrl + 'RecipeReviews/';*/'http://localhost:64480/api/RecipeReviews/';
      
      submitReview(review:RecipeReviewVM){
        return this.http.post<RecipeReviewVM>(this.reviewUrl, review).toPromise()
        .then(review => review);
      }
      getReviews(recipeId:number){
        return this.http.get<RecipeReviewVM[]>(this.reviewUrl + recipeId).toPromise()
       .then(reviews => reviews);
      }
}
