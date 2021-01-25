import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ResponseAPI } from '../models/response-api.model';
import { map, catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { Subject } from 'rxjs';
import { Inventory } from '../models/inventory.model';
import { Facturar } from '../models/facturar.model';

@Injectable({
  providedIn: 'root',
})
export class ProductoService {
  private productosSubject = new Subject<ResponseAPI>();

  constructor(private http: HttpClient) {}

  obtenerProductos() {
    this.http
      .get<ResponseAPI>(`${environment.baseUrl}product/inventory`)
      .pipe(
        catchError(() =>
          of(
            new ResponseAPI(
              false,
              500,
              'Se presentaron errores en el servidor',
              null
            )
          )
        )
      )
      .subscribe((data) => {
        this.productosSubject.next(data);
      });
  }

  agregarProducto(product: Inventory) {
    this.http.post(`${environment.baseUrl}product/addProduct`, product).subscribe(() => {
      this.obtenerProductos();
    });
  }

  facturarProducto(facturar: Facturar) {
    this.http.post(`${environment.baseUrl}product/checkin`, facturar).subscribe(() => {
      this.obtenerProductos();
    });
  }

  obtenerActualListener() {
    return this.productosSubject.asObservable();
  }
}
