USE BibliotecaDB;
GO

INSERT INTO dbo.Libros
    (Titulo, Anio, Genero, NumeroPaginas, AutorId)
VALUES
('Cien años de soledad', 1967, 'Realismo mágico', 417, 1),
('El amor en los tiempos del cólera', 1985, 'Novela romántica', 348, 1),

('La casa de los espíritus', 1982, 'Realismo mágico', 433, 2),
('Paula', 1994, 'Memoria', 320, 2),

('La ciudad y los perros', 1963, 'Novela', 400, 3),
('Conversación en La Catedral', 1969, 'Novela política', 600, 3),

('Rayuela', 1963, 'Novela experimental', 736, 4),
('Final del juego', 1956, 'Cuento', 190, 4),

('Ficciones', 1944, 'Cuentos', 174, 5),
('El Aleph', 1949, 'Cuentos', 146, 5);
GO