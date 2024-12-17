SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Id_da_categoria],
    [Categoria].[Nome] AS [Nome_da_categoria]
FROM
    [Curso]
INNER JOIN [Categoria]
    ON [Curso].[CategoriaId] = [Categoria].[Id]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Id_da_categoria],
    [Categoria].[Nome] AS [Nome_da_categoria]
FROM
    [Curso]
LEFT JOIN [Categoria]
    ON [Curso].[CategoriaId] = [Categoria].[Id]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Id_da_categoria],
    [Categoria].[Nome] AS [Nome_da_categoria]
FROM
    [Curso]
RIGHT JOIN [Categoria]
    ON [Curso].[CategoriaId] = [Categoria].[Id]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Id_da_categoria],
    [Categoria].[Nome] AS [Nome_da_categoria]
FROM
    [Curso]
FULL JOIN [Categoria]
    ON [Curso].[CategoriaId] = [Categoria].[Id]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Id_da_categoria],
    [Categoria].[Nome] AS [Nome_da_categoria]
FROM
    [Curso]
FULL OUTER JOIN [Categoria]
    ON [Curso].[CategoriaId] = [Categoria].[Id]