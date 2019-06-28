import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaAutorPage } from './lista-autor.page';

describe('ListaAutorPage', () => {
  let component: ListaAutorPage;
  let fixture: ComponentFixture<ListaAutorPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaAutorPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaAutorPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
