CREATE OR ALTER VIEW [vwInfo] AS
    SELECT
        [Course].[Name] AS [CourseName],
        [Course].[Description] AS [CourseDescription],
        [Room].[Code] AS [RoomCode],
        [Room].[SupportedStudents] AS [SupportedStudents]
    FROM
        [RoomCourse]
    INNER JOIN [Course] ON [RoomCourse].[CourseId] = [Course].[Id]
    INNER JOIN [Room] ON [RoomCourse].[RoomId] = [Room].[Id]

