/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CreateRecipeComponent } from './create-recipe.component';

let component: CreateRecipeComponent;
let fixture: ComponentFixture<CreateRecipeComponent>;

describe('CreateRecipe component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CreateRecipeComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CreateRecipeComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});