import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Inventory } from 'src/app/models/inventory.model';
import { ProductoService } from '../../services/producto.service';

@Component({
  selector: 'app-facturacion',
  templateUrl: './facturacion.component.html',
  styleUrls: ['./facturacion.component.css']
})
export class FacturacionComponent implements OnInit, OnDestroy {

  private productosSubscription: Subscription;
  unitPrice = 0;
  totalPrice = 0;
  quantity = 0;
  documentType = [];
  productos: Inventory[] = [];
  productoSeleccionado: Inventory = null;

  constructor(private productoService: ProductoService) { }

  ngOnInit(): void {
    this.documentType = [
      {value: 'CC', viewValue: 'Cedula de ciudadania'},
      {value: 'CE', viewValue: 'Cedula de extranjeria'},
      {value: 'PA', viewValue: 'Pasaporte'},
      {value: 'RC', viewValue: 'Registro civil'},
      {value: 'TI', viewValue: 'Tarjeta de identidad'}
    ];

    this.productoService.obtenerProductos();
    this.productosSubscription = this.productoService.obtenerActualListener().subscribe((resp) =>{
      if (resp.isSuccessful) {
        this.productos = resp.result.filter(x => x.quantity > 0);
      }
    });
  }

  cambiarValorUnitario(productoId: number){
    this.productoSeleccionado = this.productos.find(x => x.productId === productoId);
    this.unitPrice = this.productoSeleccionado.unitPrice;
    this.quantity = 0;
  }

  cambiarValorTotal(){
    if(this.quantity >= 0 && this.productoSeleccionado !== null){
      if(this.productoSeleccionado.quantity >= this.quantity){
        this.totalPrice = (this.unitPrice * this.quantity)
      }
    }
  }

  facturar(form: NgForm){
    if(form.valid){
      this.productoService.facturarProducto(form.value);
      this.productosSubscription = this.productoService.obtenerActualListener().subscribe(() => this.ngOnDestroy());
    }
  }

  ngOnDestroy(): void {
    this.productosSubscription.unsubscribe();
  }

}
