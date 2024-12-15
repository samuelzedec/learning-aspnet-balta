CREATE TABLE [Student](
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    [Name] NVARCHAR(50) NOT NULL,
    [Age] TINYINT NOT NULL,
    [Email] NVARCHAR(30),
    [Gender] NVARCHAR(10),
    [Phone] NVARCHAR(12),
    [RoomId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [UQ_Student_Email] UNIQUE([Email]),
    CONSTRAINT [PK_Student_Id] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Student_Room] FOREIGN KEY([RoomId])
        REFERENCES [Room]([Id])
)

CREATE INDEX [IX_Student_Email] ON [Student]([Email]);



