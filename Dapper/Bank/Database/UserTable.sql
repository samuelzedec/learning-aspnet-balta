CREATE TABLE [User](
    [Id] INT IDENTITY(1, 1),
    [FullName] VARCHAR(80) NOT NULL,
    [Cpf] VARCHAR(20) NOT NULL,
    [DateOfBirth] DATE NOT NULL,
    [Phone] VARCHAR(20) NOT NULL,
    [Email] VARCHAR(80) NOT NULL,
    [Password] VARCHAR(100) NOT NULL,

    CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_User_Cpf] UNIQUE ([Cpf]),
    CONSTRAINT [UQ_User_Email] UNIQUE ([Email])
);

CREATE NONCLUSTERED INDEX [IX_User_Email] ON [User]([Email]);