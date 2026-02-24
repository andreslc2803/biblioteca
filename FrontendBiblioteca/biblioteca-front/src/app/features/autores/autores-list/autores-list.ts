import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AutorService } from '../../../core/services/autor';
import { Autor } from '../../../core/models/models';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

@Component({
  selector: 'app-autores-list',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatPaginatorModule],
  templateUrl: './autores-list.html',
})
export class AutoresListComponent implements OnInit, AfterViewInit {
  dataSource = new MatTableDataSource<Autor>();
  displayedColumns = ['nombreCompleto', 'ciudadProcedencia', 'correoElectronico'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private autorService: AutorService) {}

  ngOnInit(): void {
    this.autorService.getAutores().subscribe({
      next: (autores) => (this.dataSource.data = autores),
      error: (err) => console.error(err),
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }
}
