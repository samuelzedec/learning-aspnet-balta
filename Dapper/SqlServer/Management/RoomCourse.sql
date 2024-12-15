CREATE TABLE [RoomCourse](
    [RoomId] UNIQUEIDENTIFIER NOT NULL,
    [CourseId] UNIQUEIDENTIFIER NOT NULL,
    [Creation] DATETIME NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT [FK_RoomCourse_RoomId] FOREIGN KEY([RoomId])
        REFERENCES [Room]([Id]),
    CONSTRAINT [FK_RoomCourse_CourseId] FOREIGN KEY([CourseId])
        REFERENCES [Course]([Id]),
    CONSTRAINT [PK_RoomCourse_Id] PRIMARY KEY([RoomId], [CourseId])
)



