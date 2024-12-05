SELECT TOP 100
    [Id], [Nome], [CategoriaId]
FROM
    [Curso]
WHERE [ID] = 1 OR
    [CategoriaId] = 1
GO