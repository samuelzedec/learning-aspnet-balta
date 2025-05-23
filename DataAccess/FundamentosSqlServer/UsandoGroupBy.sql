SELECT TOP 100
    [Categoria].[Nome],
    COUNT([Curso].[CategoriaId]) AS [Cursos]
FROM
    [Categoria]
INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
GROUP BY
    [Categoria].[Nome],
    [Curso].[CategoriaId]