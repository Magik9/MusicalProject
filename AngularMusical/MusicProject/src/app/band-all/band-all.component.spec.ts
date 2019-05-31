import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BandAllComponent } from './band-all.component';

describe('BandAllComponent', () => {
  let component: BandAllComponent;
  let fixture: ComponentFixture<BandAllComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BandAllComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BandAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
