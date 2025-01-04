import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogspotListComponent } from './blogspot-list.component';

describe('BlogspotListComponent', () => {
  let component: BlogspotListComponent;
  let fixture: ComponentFixture<BlogspotListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BlogspotListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BlogspotListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
