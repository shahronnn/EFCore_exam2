using Domain.DTOs.SubjectDTOs;
using Infrastructure.Services.SubjectServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;


    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }
    [HttpGet("Get-subjects")]
    public async Task<List<GetSubjectDTO>> GetSubjects()
    {
        return await _subjectService.GetSubjects();
    }
    [HttpGet("Get-subject")]
    public async Task<GetSubjectDTO> GetSubject(int id)
    {
        return await _subjectService.GetSubject(id);
    }
    [HttpPost("Add-subject")]
    public async Task<string> AddSubject(AddSubjectDTO addSubjectDTO)
    {
        return await _subjectService.AddSubject(addSubjectDTO);
    }
    [HttpPut("Update-subject")]
    public async Task<string> UpdateSubject(UpdateSubjectDTO updateSubjectDTO)
    {
        return await _subjectService.UpdateSubject(updateSubjectDTO);
    }
    [HttpDelete("Delete-sublect")]
    public async Task<string> DeleteSubject(int id)
    {
        return await _subjectService.DeleteSubject(id);
    }
}
