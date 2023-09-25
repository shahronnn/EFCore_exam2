using Domain.DTOs.TeacherDTOs;
using Infrastructure.Services.TeacherServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;


    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }
    [HttpGet("Get-teachers")]
    public async Task <List<GetTeacherDTO>> GetTeachers()
    {
        return await _teacherService.GetTeachers();
    }
    [HttpGet("Get-teacher")]
    public async Task <GetTeacherDTO> GetTeacher(int id)
    {
        return await _teacherService.GetTeacher(id);
    }
    [HttpPost("Add-teacher")]
    public async Task <string> AddTeacher(AddTeacherDTO addTeacherDTO)
    {
        return await _teacherService.AddTeacher(addTeacherDTO);
    }
    [HttpPut("Update-teacher")]
    public async Task <string> UpdateTeacher(UpdateTeacherDTO updateTeacherDTO)
    {
        return await _teacherService.UpdateTeacher(updateTeacherDTO);
    }
    [HttpDelete("Delete-teacher")]
    public async Task <string> DeleteTeacher(int id)
    {
        return await _teacherService.DeleteTeacher(id);
    }
}
