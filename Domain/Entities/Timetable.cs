namespace Domain.Entities;

public class Timetable
{
    public int Id { get; set; }
    public string Day { get; set; }
    public string Time { get; set; }
    public string Subject { get; set; }
    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
}
