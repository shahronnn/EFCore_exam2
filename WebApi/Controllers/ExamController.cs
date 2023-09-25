using Domain.DTOs.ExamDTOs;
using Infrastructure.Services.ExamServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamController : ControllerBase
{
    private readonly IExamService _examService;


    public ExamController(IExamService examService)
    {
        _examService = examService;

    }
    [HttpGet("Get-exams")]
    public async Task<List<GetExamDTO>> GetExams()
    {
        return await _examService.GetExams();
    }
    [HttpGet("Get-exam")]
    public async Task<GetExamDTO> GetExam(int id)
    {
        return await _examService.GetExam(id);
    }
    [HttpPost("Add-exam")]
    public async Task<string> AddExam(AddExamDTO addExamDTO)
    {
        return await _examService.AddExam(addExamDTO);
    }
    [HttpPut("Update-exam")]
    public async Task<string> UpdateExam(UpdateExamDTO updateExamDTO)
    {
        return await _examService.UpdateExam(updateExamDTO);
    }
    [HttpDelete("Delete-exam")]
    public async Task<string> DeleteExam(int id)
    {
        return await _examService.DeleteExam(id);
    }
}
