import { Categoria } from './categoria'
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',

})
export class CategoriaService {



  constructor(private http: HttpClient) {}
  readonly baseURL = 'https://localhost:5001/api/Categorias';
  Dado: Categoria = new Categoria();
  lista: any;


  getCategorias() {
    return this.http.get(this.baseURL);
  }

  refreshList() {
    this.http
      .get(this.baseURL)
      .toPromise()
      .then((res) => {
        this.lista = res as Categoria[];
      });
  }
}
