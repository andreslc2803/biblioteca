import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../enviroments/enviroment';
import { Observable } from 'rxjs';
import { Autor, CreateAutor } from '../models/models';

@Injectable({
  providedIn: 'root',
})
export class AutorService {
  private apiUrl = `${environment.apiUrl}/Autores`;

  constructor(private http: HttpClient) {}

  getAutores(): Observable<Autor[]> {
    return this.http.get<Autor[]>(this.apiUrl);
  }

  createAutor(autor: CreateAutor): Observable<CreateAutor> {
    return this.http.post<CreateAutor>(this.apiUrl, autor);
  }
}
