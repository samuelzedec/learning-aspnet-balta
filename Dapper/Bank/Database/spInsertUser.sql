CREATE OR AlTER PROCEDURE [spInsertUser](
    @FullName VARCHAR(80),
    @Cpf VARCHAR(20),
    @DateOfBirth DATETIME,
    @Phone VARCHAR(20),
    @Email VARCHAR(80),
    @Password VARCHAR(100)
) AS
    BEGIN
        INSERT INTO [User](
            [FullName], [Cpf], [DateOfBirth], [Phone], [Email], [Password]
        )
        VALUES(
               @FullName,
               @Cpf,
               @DateOfBirth,
               @Phone,
               @Email,
               @Password);
        SELECT SCOPE_IDENTITY();
    END;