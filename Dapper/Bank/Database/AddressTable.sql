CREATE TABLE [Address](
    [UserId] INT NOT NULL,
    [Road] NVARCHAR(30) NOT NULL,
    [Number] SMALLINT NOT NULL,
    [Neighborhood] NVARCHAR(15) NOT NULL,
    [City] NVARCHAR(20) NOT NULL,
    [State] NVARCHAR(20) NOT NULL,
    [ZipCode] VARCHAR(10) NOT NULL,

    CONSTRAINT [PK_Address_UserId] PRIMARY KEY ([UserId]),
    CONSTRAINT [FK_Address_UserId] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)