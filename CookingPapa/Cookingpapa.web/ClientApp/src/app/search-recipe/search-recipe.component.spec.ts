/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { SearchRecipeComponent } from './search-recipe.component';

let component: SearchRecipeComponent;
let fixture: ComponentFixture<SearchRecipeComponent>;

describe('SearchRecipe component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ SearchRecipeComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(SearchRecipeComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});