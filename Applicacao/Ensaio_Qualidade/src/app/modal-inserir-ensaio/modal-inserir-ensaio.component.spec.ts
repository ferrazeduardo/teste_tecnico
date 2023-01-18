import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalInserirEnsaioComponent } from './modal-inserir-ensaio.component';

describe('ModalInserirEnsaioComponent', () => {
  let component: ModalInserirEnsaioComponent;
  let fixture: ComponentFixture<ModalInserirEnsaioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalInserirEnsaioComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalInserirEnsaioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
