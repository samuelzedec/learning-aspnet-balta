namespace Management.Message;

public static class SqlMessage
{
    public static string SelectInRoomModel()
    {
        return 
        @"SELECT
            [Id], [Code]
        FROM
            [Room]";
    }

    public static string SelectInVwInfo()
    {
        return 
        @"SELECT
            [RoomId], [RoomCode], [SupportedStudents], [CourseName], [CourseDescription]
        FROM
            [vwInfo]
        WHERE
            [RoomCode] = @RoomCode";
    }

    public static string SelectStudents()
    {
        return
        @"SELECT 
            [Name], [Email]
        FROM
            [vwStudentCourses]
        WHERE
            [Room] = @Room";
    }
    
}
