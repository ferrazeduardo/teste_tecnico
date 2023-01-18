import { Component, Input } from '@angular/core';
import { Lotes } from '../lotes';

@Component({
  selector: 'app-ensaio-qualidade',
  templateUrl: './ensaio-qualidade.component.html',
  styleUrls: ['./ensaio-qualidade.component.css']
})
export class EnsaioQualidadeComponent {

  @Input()
  lote: any;

  metodologia: any;
  parametros: any[] = [];
  habilitarInserirEnsaio = false;

  ngOnInit() {
    this.metodologia = this.lote.metodologiaAvalicaoDTO;
    this.parametros = this.lote.parametroDTOs;
  }

  // onChange(newValue: any) {
  //   let metodologia = this.metodologias.find(m => m.id == newValue.target.value);
  //   this.habilitarInserirEnsaio = true;
  // }
}
