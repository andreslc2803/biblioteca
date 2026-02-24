export interface Autor {
  id: number; // obligatorio para autores existentes
  nombreCompleto: string;
  fechaNacimiento: string;
  ciudadProcedencia: string;
  correoElectronico: string;
}

export interface CreateAutor {
  nombreCompleto: string;
  fechaNacimiento: string;
  ciudadProcedencia: string;
  correoElectronico: string;
}

// libro.ts
export interface Libro {
  titulo: string;
  anio: number;
  genero: string;
  numeroPaginas: number;
  autorId: number;
}

// Interfaz para crear un libro (sin id)
export interface CrearLibro {
  titulo: string;
  anio: number;
  genero: string;
  numeroPaginas: number;
  autorId: number;
}
