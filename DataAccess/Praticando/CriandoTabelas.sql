CREATE TABLE [Author](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL,
    [Birth] DATE NOT NULL,
    [Housing] NVARCHAR(180) NOT NULL DEFAULT('Desconhecido'),

    CONSTRAINT [PK_Author_Id] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Author_Name] UNIQUE([Name])
)

CREATE TABLE [Category](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Category_Id] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Category_Name] UNIQUE([Name])
)

CREATE TABLE [Book](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL,
    [CategoryId] INT NOT NULL,
    [AuthorId] INT NOT NULL,
    [Launch] DATE NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_Book_Id] PRIMARY KEY([Id]) ,

    CONSTRAINT [FK_Book_Category] FOREIGN KEY([CategoryId])
        REFERENCES [Category]([Id]),

    CONSTRAINT [FK_Book_Author] FOREIGN KEY([AuthorId])
        REFERENCES [Author]([Id])
)