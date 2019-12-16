import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InmuebleAddComponent } from './inmueble-add.component';

describe('InmuebleAddComponent', () => {
  let component: InmuebleAddComponent;
  let fixture: ComponentFixture<InmuebleAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InmuebleAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InmuebleAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
