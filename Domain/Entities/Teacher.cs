using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class Teacher
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Email { get; set; }=null!;
    [MaxLength(30)]
    public string Password { get; set; }=null!;
    [MaxLength(50)]
    public string Name { get; set; }=null!;
    public DateTime? DOB { get; set; }
    public Sex Sex { get; set; }
    [MaxLength(50)]
    public string? Address { get; set; }
    [MaxLength(20)]
    public string Phone { get; set; }=null!;
    public string DateOfJoin { get; set; }
    public List<Attandance> Attandances { get; set; }
    public List<Classroom> Classrooms { get; set; }
}
