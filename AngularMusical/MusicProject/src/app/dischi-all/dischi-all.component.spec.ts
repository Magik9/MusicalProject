import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DischiAllComponent } from './dischi-all.component';

describe('DischiAllComponent', () => {
  let component: DischiAllComponent;
  let fixture: ComponentFixture<DischiAllComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DischiAllComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DischiAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
