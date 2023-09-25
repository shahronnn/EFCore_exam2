namespace Domain.DTOs.ResultDTOs;

public class AddResultDTO
{
    public List<int> Marks { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public int ExamId { get; set; }
}
