namespace Domain.DTOs.SubjectDTOs;

public class UpdateSubjectDTO
{
    public int Id { get; set; }
    public string Name { get; set; }=null!;
    public int Grade { get; set; }
    public string Description { get; set; }=null!;
    public int ClassroomId { get; set; }
}
