import { Usuarios } from './usuarios';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {


  constructor(private http: HttpClient) {}
  readonly baseURL = 'https://localhost:5001/api/Usuarios';
  formData: Usuarios = new Usuarios();
  listas: any;


  getUsuarios() {
    return this.http.get(this.baseURL);
  }

  refreshList() {
    this.http
      .get(this.baseURL)
      .toPromise()
      .then((res) => {
        this.listas = res as Usuarios[];
      });
  }
}
