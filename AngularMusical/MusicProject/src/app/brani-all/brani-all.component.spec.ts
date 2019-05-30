import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BraniAllComponent } from './brani-all.component';

describe('BraniAllComponent', () => {
  let component: BraniAllComponent;
  let fixture: ComponentFixture<BraniAllComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BraniAllComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BraniAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
