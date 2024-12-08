CREATE OR ALTER VIEW [Grouping] AS
    SELECT TOP 10
        [Book].[Id],
        [Book].[Name],
        [Author].[Name] AS [Author_Name],
        [Author].[Birth] AS [Auhtor_Birth],
        [Author].[Housing] AS [Author_Housing],
        [Category].[Name] AS [Category]
    FROM
        [Book]
    INNER JOIN [Author]
        ON [Author].[Id] = [Book].AuthorId
    INNER JOIN [Category]
        ON [Category].[Id] = [Book].CategoryId

SELECT * FROM [Grouping]

CREATE OR ALTER VIEW [NumberOfBooks] AS
    SELECT TOP 5
        [Category].[Id],
        [Category].[Name],
        COUNT([Book].[CategoryId]) AS [Books]
    FROM
        [Category]
    INNER JOIN [Book]
        ON [Book].[CategoryId] = [Category].[Id]
    GROUP BY
        [Category].[Id],
        [Category].[Name]

SELECT
    *
FROM
    [NumberOfBooks]
ORDER BY
    [Books] ASC

