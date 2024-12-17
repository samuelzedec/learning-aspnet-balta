CREATE OR ALTER VIEW [vwStudentCourses] AS
    SELECT
        [Student].[Name],
        [Student].[Email],
        [Student].[Age],
        [Student].[Gender],
        [vwInfo].[RoomCode] AS [Room],
        COUNT([vwInfo].[RoomCode]) AS [RegisteredCourses]
    FROM
        [Student]
    INNER JOIN [vwInfo] ON [vwInfo].[RoomId] = [Student].[RoomId]
    GROUP BY
        [Student].[Name],
        [Student].[Email],
        [Student].[Age],
        [Student].[Gender],
        [vwInfo].[RoomCode]
