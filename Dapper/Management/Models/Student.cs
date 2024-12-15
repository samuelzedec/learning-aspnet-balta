namespace Management.Models;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte Age { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public string  Phone { get; set; }
    public Guid RoomId { get; set; }
}
