namespace Management.Models;

public class VwInfo
{
    public Guid RoomId { get; set; }
    public string RoomCode { get; set; }
    public byte SupportedStudents { get; set; }
    public List<CourseVwInfo> Courses { get; set; } = new();
}
