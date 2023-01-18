import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { Ensaios } from '../ensaios';

@Component({
  selector: 'app-modal-inserir-ensaio',
  templateUrl: './modal-inserir-ensaio.component.html',
  styleUrls: ['./modal-inserir-ensaio.component.css']
})
export class ModalInserirEnsaioComponent {

  constructor(private http: HttpClient) {

  }

  @Input() parametrosQuestionario: any[] = [];
  @Input() loteQuestionario: number | undefined;

  displayStyle = "none";
  parametroQuantitativos: any[] = [];
  parametroQualitativos: any[] = [];
  ensaios: Ensaios[] = [];
  valoresQuantitativos: number[] = [];



  ngOnInit() {
    this.parametroQuantitativos = this.parametrosQuestionario.filter(parametro => parametro.tipo == "QUANTITATIVO");
    this.parametroQualitativos = this.parametrosQuestionario.filter(parametro => parametro.tipo == "QUALITATIVO");
  }

  async salvarEnsaio() {
    let input = document.getElementsByTagName("input");

    for (let i = 0; i < input.length; i++) {
      this.ensaios.push({
        vl_quantitativo: Number(input[i].value),
        lote: this.loteQuestionario == undefined ? 0 : this.loteQuestionario,
        parametro: Number(input[i].id),
        vl_qualitativo: ""
      })
    }

    let select = document.getElementsByTagName("select");

    for (let i = 0; i < select.length; i++) {
      console.log(select[i].value)

      this.ensaios.push({
        vl_quantitativo: 0,
        lote: this.loteQuestionario == undefined ? 0 : this.loteQuestionario,
        parametro: Number(select[i].id),
        vl_qualitativo: select[i].value
      })
    }


    await this.http.post('http://localhost:37969/api/EnsaioQualidades', this.ensaios)
      .subscribe(data => {
        this.ensaios.length = 0
        location.reload();
      });


  }


  openPopup() {
    this.displayStyle = "block";
  }
  closePopup() {
    this.displayStyle = "none";
  }

}
