using Domain.DTOs.ResultDTOs;
using Domain.Entities;
using Domain.Enums;

namespace Domain.DTOs.StudentDTOs;

public class GetStudentDTO
{
    public int Id { get; set; }
    public string Email { get; set; }=null!;
    public string Password { get; set; }=null!;
    public string Name { get; set; }=null!;
    public DateTime? DOB { get; set; }
    public Sex Sex { get; set; }
    public string? Address { get; set; }
    public string Phone { get; set; }=null!;
    public string DateOfJoin { get; set; }
    public string? ParentName { get; set; }
    public List<GetResultDTO> Results { get; set; }
}
