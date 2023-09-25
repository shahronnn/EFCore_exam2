namespace Domain.Entities;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }=null!;
    public int Grade { get; set; }
    public string Description { get; set; }=null!;
    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
    public List<Result> Results { get; set; }
}
