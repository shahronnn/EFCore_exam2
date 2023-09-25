using Domain.DTOs.Attandance;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Services.AttandanceService;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.AttandanceServices;

public class AttandanceService: IAttandanceService
{
    private readonly DataContext _dataContext;


    public AttandanceService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<string> AddStudentAttandance(AddStudentAttandanceDTO addStudentAttandanceDTO)
    {
        var attandance = new Attandance()
        {
            Date = DateTime.UtcNow,
            Status = addStudentAttandanceDTO.Status,
            StudentId = addStudentAttandanceDTO.StudentId
        };
        await _dataContext.Attandances.AddAsync(attandance);
        await _dataContext.SaveChangesAsync();
        return "Attandance added!";
    }

    public async Task<string> AddTeacherAttandance(AddTeacherAttandanceDTO addTeacherAttandanceDTO)
    {
        var attandance = new Attandance()
        {
            Date = DateTime.UtcNow,
            Status = addTeacherAttandanceDTO.Status,
            TeacherId = addTeacherAttandanceDTO.TeacherId
        };
        await _dataContext.Attandances.AddAsync(attandance);
        await _dataContext.SaveChangesAsync();
        return "Attandance added!";
    }

    public async Task<string> DeleteAttandance(int id)
    {
        var attandance = await _dataContext.Attandances.FindAsync(id);
        _dataContext.Attandances.Remove(attandance);
        await _dataContext.SaveChangesAsync();
        return "attandance daleted!";
    }

    public async Task<GetAttandanceDTO> GetAttandance(int id)
    {
        var attandance = await _dataContext.Attandances.FindAsync(id);
        var response = new GetAttandanceDTO()
        {
            Id = attandance.Id,
            Date = attandance.Date,
            Status = attandance.Status,
            TeacherId = attandance.TeacherId,
            StudentId = attandance.StudentId
        };
        return response;
    }

    public async Task<List<GetAttandanceDTO>> GetAttandances()
    {
        var attandances = await _dataContext.Attandances.Select(a=> new GetAttandanceDTO()
        {
            Id = a.Id,
            Date = a.Date,
            Status = a.Status,
            TeacherId = a.TeacherId,
            StudentId = a.StudentId
        }).ToListAsync();
        return attandances;
    }

    public async Task<string> UpdateAttandance(UpdateAttandanceDto updateAttandanceDto)
    {
        var attandance = await _dataContext.Attandances.FindAsync(updateAttandanceDto.Id);
        attandance.Date = updateAttandanceDto.Date;
        attandance.Status = updateAttandanceDto.Status;
        _dataContext.Attandances.Update(attandance);
        await _dataContext.SaveChangesAsync();
        return "Attandance updated!";
    }
}
