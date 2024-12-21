CREATE TABLE [Transaction](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [AccountId] INT NOT NULL,
    [Type] TINYINT NOT NULL,
    [Value] DECIMAL(10, 2) NOT NULL,
    [Date] DATETIME NOT NULL DEFAULT(GETDATE()),
    [Message] NVARCHAR(MAX) NOT NULL,

    CONSTRAINT [PK_Transaction] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Transaction_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id])
);