import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';

import { Inventory } from '../../models/inventory.model';
import { ProductoService } from '../../services/producto.service';
import { NuevoProductoComponent } from '../nuevo-producto/nuevo-producto.component';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit, OnDestroy {
  private productosSubscription: Subscription;
  totalProductos = 0;
  productosPorPagina = 2;
  paginaCombo = [1, 2, 5, 10];
  dataSource = new MatTableDataSource<Inventory>();
  desplegarColumnas = ['productName', 'unitPrice', 'quantity', 'purchaseDate'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginacion: MatPaginator;
  timeout: any = null;
  filterValue = null;

  constructor(private productoService: ProductoService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.productoService.obtenerProductos();
    this.productosSubscription = this.productoService.obtenerActualListener().subscribe((resp) =>{
      if (resp.isSuccessful) {
        this.dataSource = new MatTableDataSource<Inventory>(resp.result);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginacion;
        this.totalProductos = resp.result.length;
      }
    });
  }

  filtro(event: any){
    setTimeout(() => {
      if(event.keyCode != 13){
        let filterValue = event.target.value.trim().toLowerCase();
        this.dataSource.filter = filterValue;
      }
    }, 1000)
  }

  abrirDialogo() {
    const dialogRef = this.dialog.open(NuevoProductoComponent, {
      width: '550px',
    });

    dialogRef.afterClosed().subscribe(() => {
      this.productoService.obtenerProductos();
    })
  }

  ngOnDestroy(): void {
    this.productosSubscription.unsubscribe();
  }

}
