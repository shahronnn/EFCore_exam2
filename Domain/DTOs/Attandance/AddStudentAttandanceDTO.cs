namespace Domain.DTOs.Attandance;

public class AddStudentAttandanceDTO
{
    public DateTime Date { get; set; }
    public bool Status { get; set; }
    public int StudentId { get; set; }
}
