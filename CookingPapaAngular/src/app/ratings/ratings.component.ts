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

  currentUser: any;
  userId: number;

  starList: boolean[] = [true, true, true, true, true];// create a list which contains status of 5 stars
  rating: number;
  comment: string;

  review: RecipeReviewVM;
  reviews: RecipeReviewVM[];
  reviewList: any[];
  reviewed: boolean = false;

  //Create a function which receives the value counting of stars click, 
  //and according to that value we do change the value of that star in list.
  setStar(data: any) {
    this.review.recipeReviewRating = data + 1;
    for (var i = 0; i <= 4; i++) {
      if (i <= data) {
        this.starList[i] = false;
      }
      else {
        this.starList[i] = true;
      }
    }
  }
  submitReview(comment: string) {
    this.review.recipeReviewComment = comment;
    this.reviewsService.submitReview(this.review);
    this.reviewed = true;
  }
  private getUserId() {
    this.auth.userProfile$.subscribe(data => {
      this.currentUser = data;
      this.userId = <number>+ this.currentUser.sub.toString().substr(6);
    });
  }
  private getReviews() {
    this.reviewsService.getReviews(this.review.recipeId)
      .then(reviews => {
        this.reviews = reviews
        this.setUpReviews();
      });
  }
  private setUpReviews() {
    this.reviewList=[this.reviews.length-1];
    this.reviews.forEach(element => {
      console.log(element);
      this.reviewList.push({
        recipeReviewId: element.recipeReviewId,
        recipeReviewRating: [true, true, true, true, true],
        recipeReviewComment: element.recipeReviewComment
      });
      let item = this.reviewList[this.reviewList.length - 1];
      for (let i = 0; i < item.recipeReviewRating.length; i++) {
        if (i < element.recipeReviewRating) {
          item.recipeReviewRating[i] = false;
        }
        else {
          item.recipeReviewRating[i] = true;
        }
      }
    });
  }
  ngOnInit(): void {
    this.getUserId();
    this.review = {
      recipeReviewId:null,
      recipeId: this.recipeId,
      recipeReviewRating: 0,
      userId: 1,//this.userId,
      recipeReviewComment: ''
    }
    this.getReviews();
  }
}
