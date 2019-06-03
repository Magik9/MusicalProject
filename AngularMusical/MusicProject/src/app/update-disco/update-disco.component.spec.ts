import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateDiscoComponent } from './update-disco.component';

describe('UpdateDiscoComponent', () => {
  let component: UpdateDiscoComponent;
  let fixture: ComponentFixture<UpdateDiscoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateDiscoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateDiscoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
