namespace Management.Models;

public class RoomModel
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public byte SupportedStudents { get; set; }
}
