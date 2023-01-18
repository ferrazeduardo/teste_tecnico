import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnsaioQualidadeComponent } from './ensaio-qualidade.component';

describe('EnsaioQualidadeComponent', () => {
  let component: EnsaioQualidadeComponent;
  let fixture: ComponentFixture<EnsaioQualidadeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EnsaioQualidadeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EnsaioQualidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
