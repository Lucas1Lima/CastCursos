import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Log } from './log';

@Injectable({
  providedIn: 'root'
})
export class LogService {


  constructor(private http: HttpClient) {}
  readonly baseURL = 'https://localhost:5001/api/Logs';
  Dado: Log = new Log();

  postLogs() {
      return this.http.post(this.baseURL, this.Dado);
  }

}
