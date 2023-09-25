using Domain.Enums;

namespace Domain.DTOs.TeacherDTOs;

public class UpdateTeacherDTO
{
    public int Id { get; set; }
    public string Email { get; set; }=null!;
    public string Password { get; set; }=null!;
    public string Name { get; set; }=null!;
    public DateTime? DOB { get; set; }
    public Sex Sex { get; set; }
    public string? Address { get; set; }
    public string Phone { get; set; }=null!;
}
