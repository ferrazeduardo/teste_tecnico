import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Ensaio_Qualidade';

  lotes: any = [];
  habilitarTagEnsaioQualidade = false;
  habilitarTagLotes = true;
  lote: any;
  
  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    this.http
      .get("http://localhost:37969/api/Lote")
      .subscribe(data => this.lotes = data)
  }

  selecionarLoteById(id: number) {
    
    this.http
      .get(`http://localhost:37969/api/Lote/${id}`)
      .subscribe(data => {
        this.lote = data;
        if (this.lote != undefined) {
          this.habilitarTagEnsaioQualidade = true;
          this.habilitarTagLotes = false;
        }
      })

  }
}
