import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AutorPage } from './autor.page';

describe('AutorPage', () => {
  let component: AutorPage;
  let fixture: ComponentFixture<AutorPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AutorPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AutorPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
