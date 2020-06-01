import { RecipeIngredientGroupVM } from './RecipeIngredientGroupVM';
import { RecipeInformationReviewVM } from './recipeInformationReviewVM';

export interface RecipeInformationsVM{
    recipeId:number;
    recipeName:string;
    recipeOrigin:string;
    recipeCooktime:number;
    recipeDescription:string;
    recipeCreator:string;
    recipeAverageRating:number;
    recipeIngredientGroupVMs:RecipeIngredientGroupVM[];
    recipeReviewVMs: RecipeInformationReviewVM[];
}