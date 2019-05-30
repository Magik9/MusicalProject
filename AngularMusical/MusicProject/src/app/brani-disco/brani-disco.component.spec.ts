import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BraniListComponent } from './brani-disco.component';

describe('BraniListComponent', () => {
  let component: BraniListComponent;
  let fixture: ComponentFixture<BraniListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BraniListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BraniListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
