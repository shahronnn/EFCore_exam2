using Domain.DTOs;

namespace Domain.Entities;

public class Result
{
    public int Id { get; set; }
    public List<int> Marks { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int ExamId { get; set; }
    public Exam Exam { get; set; }
}
