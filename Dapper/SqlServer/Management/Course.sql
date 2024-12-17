CREATE TABLE [Course](
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT(0)

    CONSTRAINT [PK_Course_Id] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Course_Name] UNIQUE([Name])
)

CREATE INDEX [IX_Course_Name] ON [Course]([Name]);