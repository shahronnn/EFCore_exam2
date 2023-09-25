namespace Domain.Entities;

public class Classroom
{
    public int Id { get; set; }
    public string Section { get; set; }
    public int Grade { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public List<Subject> Subjects { get; set; }
    public List<StudentClassroom> StudentClassrooms { get; set; }
    public List<Timetable> Timetables { get; set; }
}
