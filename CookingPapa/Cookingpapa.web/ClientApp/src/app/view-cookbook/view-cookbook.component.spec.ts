/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ViewCookbookComponent } from './view-cookbook.component';

let component: ViewCookbookComponent;
let fixture: ComponentFixture<ViewCookbookComponent>;

describe('ViewCookbook component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ViewCookbookComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ViewCookbookComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});