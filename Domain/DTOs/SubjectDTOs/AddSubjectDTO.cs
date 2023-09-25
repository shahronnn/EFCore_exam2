namespace Domain.DTOs.SubjectDTOs;

public class AddSubjectDTO
{
    public string Name { get; set; }=null!;
    public int Grade { get; set; }
    public string Description { get; set; }=null!;
    public int ClassroomId { get; set; }
}
