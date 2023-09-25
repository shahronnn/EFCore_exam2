using Domain.DTOs.StudentDTOs;
using Infrastructure.Services.StudentServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;


    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpGet("Get-students")]
    public async Task<List<GetStudentDTO>> GetStudents()
    {
        return await _studentService.GetStudents();
    }
    [HttpGet("Get-student")]
    public async Task<GetStudentDTO> GetStudent(int id)
    {
        return await _studentService.GetStudent(id);
    }
    [HttpPost("Add-student")]
    public async Task<string> AddStudent(AddStudentDTO addStudentDTO)
    {
        return await _studentService.AddStudent(addStudentDTO);
    }
    [HttpPut("Update-student")]
    public async Task<string> UpdateStudent(UpdateStudentDTO updateStudentDTO)
    {
        return await _studentService.UpdateStudent(updateStudentDTO);
    }
    [HttpDelete("Delete-student")]
    public async Task<string> DeleteStudent(int id)
    {
        return await _studentService.DeleteStudent(id);
    }
}
