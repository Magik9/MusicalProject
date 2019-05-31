import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DischiBandComponent } from './dischi-band.component';

describe('DischiBandComponent', () => {
  let component: DischiBandComponent;
  let fixture: ComponentFixture<DischiBandComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DischiBandComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DischiBandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
