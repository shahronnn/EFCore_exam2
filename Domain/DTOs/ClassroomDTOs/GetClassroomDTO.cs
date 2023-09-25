using Domain.Entities;

namespace Domain.DTOs.ClassroomDTOs;

public class GetClassroomDTO
{
    public int Id { get; set; }
    public string Section { get; set; }
    public int Grade { get; set; }
    public int TeacherId { get; set; }
    public List<Subject> Subjects { get; set; }
}
