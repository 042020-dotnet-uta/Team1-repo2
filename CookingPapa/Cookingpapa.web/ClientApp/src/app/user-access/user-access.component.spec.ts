/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { UserAccessComponent } from './user-access.component';

let component: UserAccessComponent;
let fixture: ComponentFixture<UserAccessComponent>;

describe('UserAccess component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ UserAccessComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(UserAccessComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});