IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Author] (
    [Id] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [Age] TINYINT NOT NULL,
    [BirthDate] DATE NOT NULL,
    [Nationality] VARCHAR(100) NOT NULL,
    [Biography] NVARCHAR NOT NULL DEFAULT N'## Não há registro informado sobre sua biografia ##',
    CONSTRAINT [PK_Author] PRIMARY KEY ([Id])
);

CREATE TABLE [Client] (
    [Id] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [BirthDate] DATE NOT NULL,
    [Email] VARCHAR(255) NOT NULL,
    [Phone] VARCHAR(20) NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY ([Id])
);

CREATE TABLE [Gender] (
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Gender] PRIMARY KEY ([Id])
);

CREATE TABLE [Book] (
    [Id] INT NOT NULL IDENTITY,
    [Title] NVARCHAR(100) NOT NULL,
    [PublicationYear] SMALLINT NOT NULL DEFAULT CAST(2024 AS SMALLINT),
    [AuthorId] INT NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Book_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Author] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Address] (
    [Id] INT NOT NULL IDENTITY,
    [Road] NVARCHAR(120) NOT NULL,
    [Number] INT NOT NULL,
    [Neighborhood] NVARCHAR(120) NOT NULL,
    [City] NVARCHAR(120) NOT NULL,
    [State] NVARCHAR(120) NOT NULL,
    [ZipCode] NVARCHAR(20) NOT NULL,
    [ClientId] INT NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Address_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Client] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [ClientBook] (
    [BookId] INT NOT NULL,
    [ClientId] INT NOT NULL,
    CONSTRAINT [PK_ClientBook] PRIMARY KEY ([BookId], [ClientId]),
    CONSTRAINT [FK_ClientBook_BookId] FOREIGN KEY ([BookId]) REFERENCES [Book] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ClientBook_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Client] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [GenderBook] (
    [BookId] INT NOT NULL,
    [GenderId] INT NOT NULL,
    CONSTRAINT [PK_GenderBook] PRIMARY KEY ([BookId], [GenderId]),
    CONSTRAINT [FK_GenderBook_BookId] FOREIGN KEY ([BookId]) REFERENCES [Book] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_GenderBook_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Gender] ([Id]) ON DELETE CASCADE
);

CREATE UNIQUE INDEX [IX_Address_ClientId] ON [Address] ([ClientId]);

CREATE UNIQUE INDEX [IX_Author_Name] ON [Author] ([Name]);

CREATE INDEX [IX_Book_AuthorId] ON [Book] ([AuthorId]);

CREATE UNIQUE INDEX [IX_Book_Title] ON [Book] ([Title]);

CREATE UNIQUE INDEX [IX_Client_Email] ON [Client] ([Email]);

CREATE INDEX [IX_ClientBook_ClientId] ON [ClientBook] ([ClientId]);

CREATE UNIQUE INDEX [IX_Gender_Name] ON [Gender] ([Name]);

CREATE INDEX [IX_GenderBook_GenderId] ON [GenderBook] ([GenderId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241231204731_InitialCreation', N'9.0.0');

COMMIT;
GO

