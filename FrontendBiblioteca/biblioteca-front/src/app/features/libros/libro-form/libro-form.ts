import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AutorService } from '../../../core/services/autor';
import { LibroService } from '../../../core/services/libro';
import { Autor, CrearLibro } from '../../../core/models/models';
import { ErrorDialogComponent } from '../../../shared/components/error-dialog/error-dialog';

@Component({
  selector: 'app-libro-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatDialogModule,
  ],
  templateUrl: './libro-form.html',
  styleUrls: ['./libro-form.css'],
})
export class LibroFormComponent implements OnInit {
  autores: Autor[] = [];
  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private autorService: AutorService,
    private libroService: LibroService,
    private dialog: MatDialog,
    private router: Router,
  ) {}

  ngOnInit(): void {
    // Inicializamos el formulario dentro de ngOnInit
    this.form = this.fb.group({
      titulo: ['', Validators.required],
      anio: ['', Validators.required],
      genero: ['', Validators.required],
      numeroPaginas: [0, Validators.required],
      autorId: [0, Validators.required],
    });

    // Cargar autores
    this.autorService.getAutores().subscribe({
      next: (data) => (this.autores = data),
      error: () =>
        this.dialog.open(ErrorDialogComponent, {
          data: 'No se pudieron cargar los autores.',
        }),
    });
  }

  submit(): void {
    if (!this.form.valid) return;

    const nuevoLibro: CrearLibro = {
      titulo: this.form.value.titulo ?? '',
      anio: this.form.value.anio ?? '',
      genero: this.form.value.genero ?? '',
      numeroPaginas: this.form.value.numeroPaginas ?? 0,
      autorId: this.form.value.autorId ?? 0,
    };

    this.libroService.createLibro(nuevoLibro).subscribe({
      next: (res) => {
        console.log('Libro creado con éxito:', res); // <-- depuración
        this.router.navigate(['/libros']); // Solo aquí si todo salió bien
      },
      error: (err) => {
        console.error('Error real al crear libro:', err);
      },
    });
  }
}
