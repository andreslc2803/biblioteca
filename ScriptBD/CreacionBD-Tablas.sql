CREATE DATABASE BibliotecaDB;
GO

USE BibliotecaDB;
GO

CREATE TABLE Autores (
    Id INT IDENTITY PRIMARY KEY,
    NombreCompleto NVARCHAR(150) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    CiudadProcedencia NVARCHAR(100) NOT NULL,
    CorreoElectronico NVARCHAR(150) NOT NULL UNIQUE
);

CREATE TABLE Libros (
    Id INT IDENTITY PRIMARY KEY,
    Titulo NVARCHAR(200) NOT NULL,
    Anio INT NOT NULL,
    Genero NVARCHAR(100) NOT NULL,
    NumeroPaginas INT NOT NULL,
    AutorId INT NOT NULL,
    CONSTRAINT FK_Libro_Autor FOREIGN KEY (AutorId)
        REFERENCES Autores(Id)
);