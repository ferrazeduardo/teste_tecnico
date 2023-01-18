import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EnsaioQualidadeComponent } from './ensaio-qualidade/ensaio-qualidade.component';
import { ModalInserirEnsaioComponent } from './modal-inserir-ensaio/modal-inserir-ensaio.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    EnsaioQualidadeComponent,
    ModalInserirEnsaioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
