using Domain.DTOs.Attandance;
using Infrastructure.Services.AttandanceService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttandanceController : ControllerBase
{
    private readonly IAttandanceService _attandanceService;


    public AttandanceController(IAttandanceService attandanceService)
    {
        _attandanceService = attandanceService;
    }
    [HttpGet("Get-attandances")]
    public async Task<List<GetAttandanceDTO>> GetAttandances()
    {
        return await _attandanceService.GetAttandances();
    }
    [HttpGet("Get-attandance")]
    public async Task<GetAttandanceDTO> GetAttandance(int id)
    {
        return await _attandanceService.GetAttandance(id);
    }
    [HttpPost("Add-student-attandance")]
    public async Task<string> AddStudentAttandance(AddStudentAttandanceDTO addStudentAttandanceDTO)
    {
        return await _attandanceService.AddStudentAttandance(addStudentAttandanceDTO);
    }
    [HttpPost("Add-teacher-attandance")]
    public async Task<string> AddTeacherAttandance(AddTeacherAttandanceDTO addTeacherAttandanceDTO)
    {
        return await _attandanceService.AddTeacherAttandance(addTeacherAttandanceDTO);
    }
    [HttpPut("Update-attandance")]
    public async Task<string> UpdateAttandance(UpdateAttandanceDto updateAttandanceDto)
    {
        return await _attandanceService.UpdateAttandance(updateAttandanceDto);
    }
    [HttpDelete("Delete-attandance")]
    public async Task<string> DeleteAttandance(int id)
    {
        return await _attandanceService.DeleteAttandance(id);
    }
}
