namespace Domain.DTOs.Attandance;

public class AddTeacherAttandanceDTO
{
    public DateTime Date { get; set; }
    public bool Status { get; set; }
    public int TeacherId { get; set; }
}
