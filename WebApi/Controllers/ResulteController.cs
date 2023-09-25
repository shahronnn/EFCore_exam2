using Domain.DTOs.ResultDTOs;
using Infrastructure.Services.ResultServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResulteController : ControllerBase
{
    private readonly IResultService _resultService;


    public ResulteController(IResultService resultService)
    {
        _resultService = resultService;
    }
    [HttpGet("Get-results")]
    public async Task<List<GetResultDTO>> GetResultes()
    {
        return await _resultService.GetResultes();
    }
    [HttpGet("Get-result")]
    public async Task<GetResultDTO> GetResulte(int id)
    {
        return await _resultService.GetResulte(id);
    }
    [HttpPost("Add-result")]
    public async Task<string> AddResulte(AddResultDTO addResulteDTO)
    {
        return await _resultService.AddResulte(addResulteDTO);
    }
    [HttpPut("Update-result")]
    public async Task<string> UpdateResulte(UpdateResultDTO updateResulteDTO)
    {
        return await _resultService.UpdateResulte(updateResulteDTO);
    }
    [HttpDelete("Delete-result")]
    public async Task<string> DeleteResulte(int id)
    {
        return await _resultService.DeleteResulte(id);
    }
}
