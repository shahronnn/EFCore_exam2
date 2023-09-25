namespace Domain.DTOs.ExamDTOs;

public class UpdateExamDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public int Type { get; set; }
}
