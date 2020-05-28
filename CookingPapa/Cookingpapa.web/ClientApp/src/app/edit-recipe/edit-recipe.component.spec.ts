/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { EditRecipeComponent } from './edit-recipe.component';

let component: EditRecipeComponent;
let fixture: ComponentFixture<EditRecipeComponent>;

describe('EditRecipe component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ EditRecipeComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(EditRecipeComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});