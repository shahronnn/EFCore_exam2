namespace Domain.DTOs.TimetableDTOs;

public class GetTimetableDTO
{
    public int Id { get; set; }
    public string Day { get; set; }
    public string Time { get; set; }
    public string Subject { get; set; }
    public int ClassroomId { get; set; }
}
