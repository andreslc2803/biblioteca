import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { AutorService } from '../../../core/services/autor';
import { CreateAutor } from '../../../core/models/models';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-autor-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
  ],
  templateUrl: './autor-form.html',
  styleUrls: ['./autor-forms.css'],
})
export class AutorFormComponent {
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private autorService: AutorService,
    private dialog: MatDialog,
    private router: Router,
  ) {
    this.form = this.fb.group({
      nombreCompleto: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      ciudadProcedencia: ['', Validators.required],
      correoElectronico: ['', [Validators.required, Validators.email]],
    });
  }

  // Método para enviar el formulario
  submit(): void {
    if (!this.form.valid) return;

    const autor: CreateAutor = {
      nombreCompleto: this.form.value.nombreCompleto ?? '',
      fechaNacimiento: this.form.value.fechaNacimiento ?? '',
      ciudadProcedencia: this.form.value.ciudadProcedencia ?? '',
      correoElectronico: this.form.value.correoElectronico ?? '',
    };

    this.autorService.createAutor(autor).subscribe({
      next: (res) => {
        console.log('Autor creado con éxito:', res);
        this.router.navigate(['/autores']);
      },
      error: (err) => {
        console.error('Error real al crear autor:', err);
      },
    });
  }
}
