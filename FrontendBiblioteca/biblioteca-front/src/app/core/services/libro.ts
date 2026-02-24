import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../enviroments/enviroment';
import { CrearLibro, Libro } from '../models/models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LibroService {
  private apiUrl = `${environment.apiUrl}/Libros`;

  constructor(private http: HttpClient) {}

  getLibros(): Observable<Libro[]> {
    return this.http.get<Libro[]>(this.apiUrl);
  }

  createLibro(libro: CrearLibro): Observable<Libro> {
    return this.http.post<Libro>(this.apiUrl, libro);
  }
}
