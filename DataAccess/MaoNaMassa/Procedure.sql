CREATE OR ALTER PROCEDURE [spStudentProgress](
    @StudentId UNIQUEIDENTIFIER
)
AS
    SELECT
        [Student].[Name] AS [Student],
        [Course].[Title] AS [Course],
        [StudentCourse].[Progress],
        [StudentCourse].[LastUpdateDate]
    FROM
        [StudentCourse]
        INNER JOIN [Student] ON [StudentCourse].[StudentId] = [Student].[Id]
        INNER JOIN [Course] ON [StudentCourse].[CourseId] = [Course].[Id]
    WHERE
        [StudentCourse].[StudentId] = @StudentId
        AND [StudentCourse].[Progress] < 100
        AND [StudentCourse].[Progress] > 0

EXEC spStudentProgress 'C55390D4-71DD-4F3C-B978-D1582F51A327'