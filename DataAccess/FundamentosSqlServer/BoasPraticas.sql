BEGIN TRANSACTION
    UPDATE
        [Categoria]
    SET
        [Nome] = 'Backend'
    WHERE
        [Nome] = ''
COMMIT
SELECT *  FROM [Categoria]

-- ROLLBACK: Caso a transção feita não saia como esperada, usamos o ROLLBACK para voltar aos padrões
-- COMMIT: Caso tudo saia como esperado, podemos usar o COMMIT para salvar essa alteração