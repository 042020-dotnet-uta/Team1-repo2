//For put/post RecipeReviewController
export interface RecipeReviewVM{
    RecipeReviewId: number | null;
    UserId: number;
    RecipeId: number;
    RecipeReviewRating: 0|1|2|3|4|5;
    RecipeReviewComment: string;
}