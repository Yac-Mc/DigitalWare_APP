import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ProductoService } from '../../services/producto.service';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-nuevo-producto',
  templateUrl: './nuevo-producto.component.html',
  styleUrls: ['./nuevo-producto.component.css']
})
export class NuevoProductoComponent implements OnInit {
  nuevoProductoSubscription: Subscription;

  constructor(private productoService: ProductoService, private dialogRef: MatDialog) { }

  ngOnInit(): void {
  }

  guardarLibro(form: NgForm){
    if(form.valid){
      this.productoService.agregarProducto(form.value);
      this.nuevoProductoSubscription = this.productoService.obtenerActualListener().subscribe(() => {
        this.dialogRef.closeAll();
      })
    }
  }

  ngOnDestroy(): void {
    this.nuevoProductoSubscription.unsubscribe();
  }

}
