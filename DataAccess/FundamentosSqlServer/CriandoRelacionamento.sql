USE [CursoPratica]

CREATE TABLE [Aluno](
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Nascimento] DATETIME NULL DEFAULT(GETDATE()),
    [IsActive] BIT NULL DEFAULT(0),

    CONSTRAINT [PK_Aluno_Id] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Aluno_Email] UNIQUE([Email])
)
GO


CREATE TABLE [Categoria](
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Categoria_Id] PRIMARY KEY([Id])
)
GO

CREATE TABLE [Curso](
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(180),
    [CategoriaId] INT NOT NULL,

    CONSTRAINT [PK_Curso_Id] PRIMARY KEY([Id]),

    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId])
        REFERENCES [Categoria]([Id])
)
GO

CREATE TABLE [ProgressoCurso](
    [AlunoId] INT NOT NULL,
    [CursoId] INT NOT NULL,
    [Progresso] INT NOT NULL,
    [UltimaAtualizacao] DATETIME NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_ProgressoCurso] PRIMARY KEY([AlunoId], [CursoId])
)
GO

CREATE INDEX [IX_Aluno_Email] ON [Aluno]([Email])
