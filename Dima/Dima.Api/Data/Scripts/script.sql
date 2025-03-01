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
CREATE TABLE [Category] (
    [Id] BIGINT NOT NULL IDENTITY,
    [Title] NVARCHAR(80) NOT NULL,
    [Description] NVARCHAR(255) NULL,
    [UserId] VARCHAR(160) NOT NULL,
    CONSTRAINT [PK_Category_Id] PRIMARY KEY ([Id])
);

CREATE TABLE [Transaction] (
    [Id] BIGINT NOT NULL IDENTITY,
    [Title] NVARCHAR(80) NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [PaidOrReceiveAt] DATETIME2 NULL,
    [Type] SMALLINT NOT NULL,
    [Amount] MONEY NOT NULL,
    [CategoryId] BIGINT NOT NULL,
    [UserId] VARCHAR(160) NOT NULL,
    CONSTRAINT [PK_Transaction_Id] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transaction_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Transaction_CategoryId] ON [Transaction] ([CategoryId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250227005824_v1', N'9.0.2');

COMMIT;
GO

