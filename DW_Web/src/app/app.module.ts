import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule } from '@angular/forms';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ProductoComponent } from './components/producto/producto.component';
import { BarraComponent } from './components/barra/barra.component';
import { FacturacionComponent } from './components/facturacion/facturacion.component';
import { MenuListaComponent } from './components/menu-lista/menu-lista.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { NuevoProductoComponent } from './components/nuevo-producto/nuevo-producto.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductoComponent,
    BarraComponent,
    FacturacionComponent,
    MenuListaComponent,
    InicioComponent,
    NuevoProductoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    {provide: MAT_DATE_LOCALE, useValue: 'es-CO'}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
