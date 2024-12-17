BEGIN TRANSACTION
    UPDATE
        [Book]
    SET
        [Name] = 'Harry Poter'
    WHERE
        [Name] = 'Harry Potter and the Sorcerers Stone'
    SELECT [Name] FROM [Book]

BEGIN TRANSACTION
    DELETE
        [Book]
    WHERE
        [Name] = 'The Hobbit'
    SELECT [Name] FROM [Book]

ROLLBACK