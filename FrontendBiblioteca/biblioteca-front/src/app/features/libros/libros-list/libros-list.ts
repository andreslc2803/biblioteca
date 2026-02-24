import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LibroService } from '../../../core/services/libro';
import { Libro } from '../../../core/models/models';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

@Component({
  selector: 'app-libros-list',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatPaginatorModule],
  templateUrl: './libros-list.html',
})
export class LibrosListComponent implements OnInit, AfterViewInit {
  dataSource = new MatTableDataSource<Libro>();
  displayedColumns = ['titulo', 'anio', 'genero', 'numeroPaginas', 'autorId'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private libroService: LibroService) {}

  ngOnInit(): void {
    this.libroService.getLibros().subscribe({
      next: (libros) => (this.dataSource.data = libros),
      error: (err) => console.error(err),
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }
}
