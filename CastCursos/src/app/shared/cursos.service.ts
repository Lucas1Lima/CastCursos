import { Cursos } from './cursos';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',

})
export class CursosService {

  constructor(private http: HttpClient) {}
  readonly baseURL = 'https://localhost:5001/api/Cursos';
  formData: Cursos = new Cursos();
  list: Cursos[];

  postCursos() {
    return this.http.post(this.baseURL, this.formData);
  }
  putCursos() {
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }
  deleteCursos(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList() {
    this.http
      .get(this.baseURL)
      .toPromise()
      .then(res => {this.list = res as Cursos[];
      });
  }
  
}
