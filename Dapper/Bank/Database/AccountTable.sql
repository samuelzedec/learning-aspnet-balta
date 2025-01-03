CREATE TABLE [Account](
    [Id] INT NOT NULL,
    [UserId] INT NOT NULL,
    [Balance] DECIMAL NOT NULL,
    [Opening] DATETIME NOT NULL DEFAULT(GETDATE()),
    [AccountType] VARCHAR(100) NOT NULL,

    CONSTRAINT [PK_Account] PRIMARY KEY([Id],[UserId]),
    CONSTRAINT [FK_Account_UserId] FOREIGN KEY([UserId]) REFERENCES [User]([Id])
);