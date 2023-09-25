namespace Domain.Entities;

public class StudentClassroom
{
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
}
