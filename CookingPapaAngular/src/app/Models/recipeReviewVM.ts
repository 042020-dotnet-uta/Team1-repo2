//For put/post RecipeReviewController
export interface RecipeReviewVM{
    recipeReviewId: number | null;
    userId: number;
    recipeId: number;
    recipeReviewRating: 0|1|2|3|4|5;
    recipeReviewComment: string;
}