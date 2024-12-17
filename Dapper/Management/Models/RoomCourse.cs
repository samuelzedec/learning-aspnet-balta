namespace Management.Models;

public class RoomCourse
{
    public Guid RoomId { get; set; }
    public Guid CourseId { get; set; }
    public DateTime Creation { get; set; }
}
