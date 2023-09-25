using Domain.Entities;

namespace Domain.DTOs;

public class Exam
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public int Type { get; set; }
    public List<Result> Results { get; set; }
}
