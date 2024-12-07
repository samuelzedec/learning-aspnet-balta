BEGIN TRANSACTION
    DELETE
        [Curso]
    WHERE
        [CategoriaId] = 3

    DELETE
        [Categoria]
    WHERE
        [Id] = 3

ROLLBACK

SELECT * FROM [Categoria]
SELECT * FROM [Curso]
