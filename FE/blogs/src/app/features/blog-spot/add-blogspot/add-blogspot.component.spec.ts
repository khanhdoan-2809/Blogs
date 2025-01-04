import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBlogspotComponent } from './add-blogspot.component';

describe('AddBlogspotComponent', () => {
  let component: AddBlogspotComponent;
  let fixture: ComponentFixture<AddBlogspotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddBlogspotComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddBlogspotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
