using Domain.DTOs.ResultDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.ResultServices;

public class ResulteService: IResultService
{
    private readonly DataContext _dataContext;


    public ResulteService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<string> AddResulte(AddResultDTO addResulteDTO)
    {
        var resulte = new Result()
        {
            Marks = addResulteDTO.Marks,
            StudentId = addResulteDTO.StudentId,
            SubjectId = addResulteDTO.SubjectId,
            ExamId = addResulteDTO.ExamId
        };
        await _dataContext.Results.AddAsync(resulte);
        _dataContext.SaveChanges();
        return "Result added!";
    }

    public async Task<string> DeleteResulte(int id)
    {
        var resulte = await _dataContext.Results.FindAsync(id);
        _dataContext.Results.Remove(resulte);
        await _dataContext.SaveChangesAsync();
        return "Resulte deleted!";
    }

    public async Task<GetResultDTO> GetResulte(int id)
    {
        var result = await _dataContext.Results.FindAsync(id);
        var response = new GetResultDTO()
        {
            Id = result.Id,
            Marks = result.Marks,
            StudentId = result.StudentId,
            SubjectId = result.SubjectId,
            ExamId = result.ExamId
        };
        return response;
    }

    public async Task<List<GetResultDTO>> GetResultes()
    {
        var results = await _dataContext.Results.Select(r=> new GetResultDTO()
        {
            Id = r.Id,
            Marks = r.Marks,
            StudentId = r.StudentId,
            SubjectId = r.SubjectId,
            ExamId = r.ExamId
        }).ToListAsync();
        return results;
    }

    public async Task<string> UpdateResulte(UpdateResultDTO updateResulteDTO)
    {
        var result = await _dataContext.Results.FindAsync(updateResulteDTO.Id);
        result.Id = updateResulteDTO.Id;
        result.Marks = updateResulteDTO.Marks;
        result.StudentId = updateResulteDTO.StudentId;
        result.SubjectId = updateResulteDTO.SubjectId;
        result.ExamId = updateResulteDTO.ExamId;
        _dataContext.Update(result);
        await _dataContext.SaveChangesAsync();
        return "Resulte updated!";
    }
}
