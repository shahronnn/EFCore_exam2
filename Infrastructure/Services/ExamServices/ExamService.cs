using Domain.DTOs;
using Domain.DTOs.ExamDTOs;
using Infrastructure.Data;
using Infrastructure.Services.ExamServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ExamService: IExamService
{
    private readonly DataContext _dataContext;


    public ExamService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<string> AddExam(AddExamDTO addExamDTO)
    {
        var exam = new Exam()
        {
            Date = addExamDTO.Date,
            Name = addExamDTO.Name,
            Type = addExamDTO.Type
        };
        if(exam == null) return "Error";
        await _dataContext.Exams.AddAsync(exam);
        await _dataContext.SaveChangesAsync();
        return "Exam added!";
    }

    public async Task<string> DeleteExam(int id)
    {
        var exam = _dataContext.Exams.Find(id);
        if(exam == null) return "Error";
        _dataContext.Exams.Remove(exam);
        await _dataContext.SaveChangesAsync();
        return "Exam deleted";
    }

    public async Task<GetExamDTO> GetExam(int id)
    {
        var exam = _dataContext.Exams.Find(id);
        var response = new GetExamDTO()
        {
            Id = exam.Id,
            Date = exam.Date,
            Name = exam.Name,
            Type = exam.Type
        };
        return response;
    }

    public async Task<List<GetExamDTO>> GetExams()
    {
        var exams = await _dataContext.Exams.Select(e=> new GetExamDTO()
        {
            Id = e.Id,
            Date = e.Date,
            Name = e.Name,
            Type = e.Type
        }).ToListAsync();
        return exams;
    }

    public async Task<string> UpdateExam(UpdateExamDTO updateExamDTO)
    {
        var exam = await _dataContext.Exams.FindAsync(updateExamDTO.Id);
        exam.Id = updateExamDTO.Id;
        exam.Date = updateExamDTO.Date;
        exam.Name = updateExamDTO.Name;
        exam.Type = updateExamDTO.Type;
        _dataContext.Exams.Update(exam);
        await _dataContext.SaveChangesAsync();
        return "Exam updated!";
    }

}
