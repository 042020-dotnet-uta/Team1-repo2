import { Component, OnInit, Input } from '@angular/core';

import { AuthService } from '../auth.service';

import { RecipeReviewVM } from '../Models/recipeReviewVM';
import { ReviewsService } from '../reviews.service';

@Component({
  selector: 'app-ratings',
  templateUrl: './ratings.component.html',
  styleUrls: ['./ratings.component.css']
})
export class RatingsComponent implements OnInit {
  constructor(public auth: AuthService, 
              private reviewsService: ReviewsService) { }

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
        this.review.RecipeReviewRating=data+1;                               
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
     this.review.RecipeReviewComment = comment;
     this.reviewsService.submitReview(this.review);
   }
   private getUserId(){
    this.auth.userProfile$.subscribe(data => {
      this.currentUser = data;
      this.userId = <number> + this.currentUser.sub.toString().substr(6);
    });
   }
   private getReviews(){
      this.reviewsService.getReviews(this.recipeId)
      .then(reviews => this.reviews = reviews);
   }
  ngOnInit(): void {
    this.getUserId();
    this.review = {
      RecipeReviewId:null,
      RecipeId: this.recipeId,
      RecipeReviewRating:0,
      UserId: 1,//this.userId,
      RecipeReviewComment: ''
    }
    this.getReviews();
  }
}
