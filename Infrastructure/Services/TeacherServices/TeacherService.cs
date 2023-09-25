using Domain.DTOs.TeacherDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.TeacherServices;

public class TeacherService: ITeacherService
{
    private readonly DataContext _dataContext;


    public TeacherService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<string> AddTeacher(AddTeacherDTO addTeacherDTO)
    {
        var teacher = new Teacher()
        {
            Email = addTeacherDTO.Email,
            Password = addTeacherDTO.Password,
            Name = addTeacherDTO.Name,
            DOB = addTeacherDTO.DOB,
            Sex = addTeacherDTO.Sex,
            Address = addTeacherDTO.Address,
            Phone = addTeacherDTO.Phone,
            DateOfJoin = addTeacherDTO.DateOfJoin
        };
        await _dataContext.Teachers.AddAsync(teacher);
        await _dataContext.SaveChangesAsync();
        return "Teacher added!";
    }

    public async Task<string> DeleteTeacher(int id)
    {
        var teacher = await _dataContext.Teachers.FindAsync(id);
        if (teacher == null) return "Data not found!";
        _dataContext.Teachers.Remove(teacher);
        await _dataContext.SaveChangesAsync();
        return "Teacher deleted!";
    }

    public async Task<GetTeacherDTO> GetTeacher(int id)
    {
        var teacher = await _dataContext.Teachers.FindAsync(id);
        var response = new GetTeacherDTO()
        {
            Id = teacher.Id,
            Email = teacher.Email,
            Password = teacher.Password,
            Name = teacher.Name,
            DOB = teacher.DOB,
            Sex = teacher.Sex,
            Address = teacher.Address,
            Phone = teacher.Phone,
            DateOfJoin = teacher.DateOfJoin
        };
        return response;
    }

    public async Task<List<GetTeacherDTO>> GetTeachers()
    {
        var teachers = await _dataContext.Teachers.Select(t=> new GetTeacherDTO()
        {
            Id = t.Id,
            Email = t.Email,
            Password = t.Password,
            Name = t.Name,
            DOB = t.DOB,
            Sex = t.Sex,
            Address = t.Address,
            Phone = t.Phone,
            DateOfJoin = t.DateOfJoin
        }).ToListAsync();
        if (teachers == null) return new List<GetTeacherDTO>();
        return teachers;
    }

    public async Task<string> UpdateTeacher(UpdateTeacherDTO updateTeacherDTO)
    {
        var teacher = await _dataContext.Teachers.FindAsync(updateTeacherDTO.Id);
        teacher.Id = updateTeacherDTO.Id;
        teacher.Email = updateTeacherDTO.Email;
        teacher.Password = updateTeacherDTO.Password;
        teacher.DOB = updateTeacherDTO.DOB;
        teacher.Sex = updateTeacherDTO.Sex;
        teacher.Address = updateTeacherDTO.Address;
        teacher.Phone = updateTeacherDTO.Phone;
        await _dataContext.SaveChangesAsync();
        if (teacher == null) return "Error";
        return "Teacher updated!";
    }

}
