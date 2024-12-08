SELECT TOP 100
    MIN([Id]) -- Aqui ele irá exibir o menor valor da coluna [Id]
FROM
    [Curso]

SELECT TOP 100
    MAX([Id]) -- Aqui ele irá retornar o maior valor coluna [Id]
FROM
    [Curso]

SELECT TOP 100
    COUNT([Id]) -- Aqui iremos fazer a soma de quantos elementos a tabela [Id] possui
FROM
    [Curso]

SELECT TOP 100
    AVG([Id]) -- Aqui iremos fazer a soma de todos elementos e dividir pela quantidade, sendo assim tirando a media
FROM
    [Curso]

SELECT TOP 100
    SUM([Id]) -- Aqui iremos fazer a soma dos valores da coluna [Id]
FROM
    [Curso]