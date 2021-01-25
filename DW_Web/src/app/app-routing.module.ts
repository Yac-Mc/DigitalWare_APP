import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InicioComponent } from './components/inicio/inicio.component';
import { ProductoComponent } from './components/producto/producto.component';
import { FacturacionComponent } from './components/facturacion/facturacion.component';

const routes: Routes = [
  // { path: 'inicio', component: InicioComponent },
  { path: 'productos', component: ProductoComponent },
  { path: 'facturacion', component: FacturacionComponent },
  { path: '**', pathMatch: 'full', redirectTo: 'facturacion'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
