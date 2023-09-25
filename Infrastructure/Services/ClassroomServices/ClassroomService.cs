using Domain.DTOs.ClassroomDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.ClassroomServices;

public class ClassroomService: IClassroomService
{
    private readonly DataContext _dataContext;


    public ClassroomService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<string> AddClassroom(AddClassroomDTO addClassroomDTO)
    {
        var classroom = new Classroom()
        {
            Section = addClassroomDTO.Section,
            Grade = addClassroomDTO.Grade,
            TeacherId = addClassroomDTO.TeacherId
        };
        await _dataContext.Classrooms.AddRangeAsync(classroom);
        await _dataContext.SaveChangesAsync();
        return "Classromm added!";
    }

    public async Task<string> DeleteClassroom(int id)
    {
        var classroom = await _dataContext.Classrooms.FindAsync(id);
        _dataContext.Classrooms.Remove(classroom);
        await _dataContext.SaveChangesAsync();
        return "Classroom deleted!";
    }

    public async Task<GetClassroomDTO> GetClassroom(int id)
    {
        var classroom = await _dataContext.Classrooms.FindAsync(id);
        var response = new GetClassroomDTO()
        {
            Id = classroom.Id,
            Section = classroom.Section,
            Grade = classroom.Grade,
            TeacherId = classroom.TeacherId
        };
        return response;
    }

    public async Task<List<GetClassroomDTO>> GetClassrooms()
    {
        var classrooms = await _dataContext.Classrooms.Select(c=> new GetClassroomDTO()
        {
            Id = c.Id,
            Section = c.Section,
            Grade = c.Grade,
            TeacherId = c.TeacherId
        }).ToListAsync();
        return classrooms;
    }

    public async Task<string> UpdateClassroom(UpdateClassroomDTO updateClassroomDTO)
    {
        var classroom = await _dataContext.Classrooms.FindAsync(updateClassroomDTO.Id);
        classroom.Id = updateClassroomDTO.Id;
        classroom.Section = updateClassroomDTO.Section;
        classroom.Grade = updateClassroomDTO.Grade;
        classroom.TeacherId = updateClassroomDTO.TeacherId;
        _dataContext.Classrooms.Update(classroom);
        await _dataContext.SaveChangesAsync();
        return "Classroom updated!";
    }
}
