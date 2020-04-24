import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Loja } from "../model/loja.model";
import { Observable } from "rxjs/index";
import { ApiResponse } from "../model/api.response";

@Injectable()
export class ApiService {

  constructor(private http: HttpClient) { }
  baseUrl: string = 'http://localhost:56632';
  header = new HttpHeaders()
  .set('Content-type', 'application/json');

  login(loginPayload) : Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl + '/token/generate-token', loginPayload);
  }

  getLojas() : Observable<Loja[]> {
    return this.http.get<Loja[]>(this.baseUrl + "/api/Loja/list");
  }

  getLojaById(idLoja: number): Observable<Loja> {
    return this.http.get<Loja>(this.baseUrl + "/api/Loja/getById/" + idLoja);
  }

  createLoja(loja: Loja): Observable<Loja> {
    const data = JSON.stringify(loja);
    return this.http.post<Loja>(this.baseUrl + "/api/Loja/insert/", data, { headers: this.header});
  }

  updateLoja(loja: Loja): Observable<Loja> {
    const data = JSON.stringify(loja);
    return this.http.put<Loja>(this.baseUrl + "/api/Loja/update/" + loja.idLoja, data, { headers: this.header});
  }

  deleteLoja(idLoja: number): Observable<ApiResponse> {
    return this.http.delete<ApiResponse>(this.baseUrl + "/api/Loja/delete/" + idLoja);
  }
}
