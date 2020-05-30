import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewCookbookComponent } from './view-cookbook.component';

describe('ViewCookbookComponent', () => {
  let component: ViewCookbookComponent;
  let fixture: ComponentFixture<ViewCookbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewCookbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewCookbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
