import { Routes } from '@angular/router';
import { AutoresListComponent } from './features/autores/autores-list/autores-list';
import { LibrosListComponent } from './features/libros/libros-list/libros-list';
import { AutorFormComponent } from './features/autores/autor-form/autor-form';
import { LibroFormComponent } from './features/libros/libro-form/libro-form';

export const routes: Routes = [
  { path: '', redirectTo: 'autores', pathMatch: 'full' },

  { path: 'autores', component: AutoresListComponent },
  { path: 'autores/nuevo', component: AutorFormComponent },

  { path: 'libros', component: LibrosListComponent },
  { path: 'libros/nuevo', component: LibroFormComponent },

  { path: '**', redirectTo: 'autores' },
];
