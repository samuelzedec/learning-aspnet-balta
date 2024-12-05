USE [Cursos]

CREATE TABLE [Categoria](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Nome] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Categoria_Id] PRIMARY KEY([Id])
)
GO

CREATE TABLE [Curso](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Nome] NVARCHAR(80) NOT NULL,
    [CategoriaId] INT NOT NULL,

    CONSTRAINT [PK_Curso_Id] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Categoria_Id] FOREIGN KEY([CategoriaId])
        REFERENCES [Categoria]([Id])
)
GO