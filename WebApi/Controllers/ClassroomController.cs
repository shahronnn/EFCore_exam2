using Domain.DTOs.ClassroomDTOs;
using Infrastructure.Services.ClassroomServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassroomController : ControllerBase
{
    private readonly IClassroomService _classroomService;


    public ClassroomController(IClassroomService classroomService)
    {
        _classroomService = classroomService;
    }
    [HttpGet("Get-classrooms")]
    public async Task<List<GetClassroomDTO>> GetClassrooms()
    {
        return await _classroomService.GetClassrooms();
    }
    [HttpGet("Get-classroom")]
    public async Task<GetClassroomDTO> GetClassroom(int id)
    {
        return await _classroomService.GetClassroom(id);
    }
    [HttpPost("Add-classroom")]
    public async Task<string> AddClassroom(AddClassroomDTO addClassroomDTO)
    {
        return await _classroomService.AddClassroom(addClassroomDTO);
    }
    [HttpPut("Update-classroom")]
    public async Task<string> UpdateClassroom(UpdateClassroomDTO updateClassroomDTO)
    {
        return await _classroomService.UpdateClassroom(updateClassroomDTO);
    }
    [HttpDelete("Delete-classroom")]
    public async Task<string> DeleteClassroom(int id)
    {
        return await _classroomService.DeleteClassroom(id);
    }
}
