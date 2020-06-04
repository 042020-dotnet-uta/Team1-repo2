import { Component, OnInit, Input } from '@angular/core';

import { AuthService } from '../auth.service';

import { RecipeReviewVM } from '../Models/recipeReviewVM';
import { ReviewsService } from '../reviews.service';
import { ITS_JUST_ANGULAR } from '@angular/core/src/r3_symbols';

@Component({
  selector: 'app-ratings',
  templateUrl: './ratings.component.html',
  styleUrls: ['./ratings.component.css']
})
export class RatingsComponent implements OnInit {
  constructor(public auth: AuthService, 
              private reviewsService: ReviewsService) {  }

  @Input() recipeId: number;

  currentUser:any;
  userId : number;

  starList: boolean[] = [true,true,true,true,true];// create a list which contains status of 5 stars
  rating:number;  
  comment:string;

  review: RecipeReviewVM;
  reviews: RecipeReviewVM[];

  //Create a function which receives the value counting of stars click, 
  //and according to that value we do change the value of that star in list.
  setStar(data:any){
        this.review.recipeReviewRating=data+1;                               
        for(var i=0;i<=4;i++){  
          if(i<=data){  
            this.starList[i]=false;  
          }  
          else{  
            this.starList[i]=true;  
          }  
       }  
   }
   submitReview(comment:string){
     this.review.recipeReviewComment = comment;
     this.reviewsService.submitReview(this.review);
   }
   private getUserId(){
    this.auth.userProfile$.subscribe(data => {
      this.currentUser = data;
      this.userId = <number> + this.currentUser.sub.toString().substr(6);
    });
   }
   private getReviews(){
      this.reviewsService.getReviews(this.review.recipeId)
      .then(reviews => this.reviews = reviews);

     this.reviews.forEach(element => {
       console.log(element.recipeReviewRating);
     });
   }
  ngOnInit(): void {
    this.getUserId();
    this.review = {
      recipeReviewId:null,
      recipeId: this.recipeId,
      recipeReviewRating:0,
      userId: this.userId,
      recipeReviewComment: ''
    }
    this.getReviews();
  }
}
