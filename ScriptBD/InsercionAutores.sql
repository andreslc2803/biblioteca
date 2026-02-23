USE BibliotecaDB;
GO

INSERT INTO dbo.Autores
    (NombreCompleto, FechaNacimiento, CiudadProcedencia, CorreoElectronico)
VALUES
('Gabriel García Márquez', '1927-03-06', 'Aracataca', 'gabriel.garcia@email.com'),
('Isabel Allende', '1942-08-02', 'Lima', 'isabel.allende@email.com'),
('Mario Vargas Llosa', '1936-03-28', 'Arequipa', 'mario.vargas@email.com'),
('Julio Cortázar', '1914-08-26', 'Bruselas', 'julio.cortazar@email.com'),
('Jorge Luis Borges', '1899-08-24', 'Buenos Aires', 'jorge.borges@email.com');
GO