export interface RecipeReviewPostVM{
    userId: number;
    recipeId: number;
    recipeReviewRating: 0|1|2|3|4|5;
    recipeReviewComment: string;
}