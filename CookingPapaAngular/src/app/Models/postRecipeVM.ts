import {RecipeIngredientGroupVM} from './recipeIngredientGroupVM'

export interface PostRecipeVM{
    RecipeId?: number;
    UserId: number;
    RecipeOriginName: string;
    RecipeName: string;
    RecipeCookTime: number;
    RecipeInstruction: string;
    RecipeIngredientGroupVM: RecipeIngredientGroupVM[];
}