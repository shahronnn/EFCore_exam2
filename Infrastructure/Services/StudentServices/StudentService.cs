using Domain.DTOs.ResultDTOs;
using Domain.DTOs.StudentDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentServices;

public class StudentService : IStudentService
{
    private readonly DataContext _dataContext;


    public StudentService(DataContext dataContext)
    {
        _dataContext = dataContext;

    }

    public async Task<string> AddStudent(AddStudentDTO addStudentDTO)
    {
        var student = new Student()
        {
            Email = addStudentDTO.Email,
            Password = addStudentDTO.Password,
            Name = addStudentDTO.Name,
            DOB = addStudentDTO.DOB,
            Sex = addStudentDTO.Sex,
            Address = addStudentDTO.Address,
            Phone = addStudentDTO.Phone,
            DateOfJoin = addStudentDTO.DateOfJoin,
            ParentName = addStudentDTO.ParentName
        };
        if (student == null) return "Error";
        _dataContext.Students.Add(student);
        _dataContext.SaveChanges();
        return "Student Added!";
    }

    public async Task<string> DeleteStudent(int id)
    {
        var student = await _dataContext.Students.FindAsync(id);
        if (student == null) return "Not found!";
        _dataContext.Students.Remove(student);
        await _dataContext.SaveChangesAsync();
        return "Student deleted!";
    }

    public async Task<GetStudentDTO> GetStudent(int id)
    {
        var student = await _dataContext.Students.FindAsync(id);
        var response = new GetStudentDTO()
        {
            Id = student.Id,
            Email = student.Email,
            Password = student.Password,
            Name = student.Name,
            DOB = student.DOB,
            Sex = student.Sex,
            Address = student.Address,
            Phone = student.Phone,
            DateOfJoin = student.DateOfJoin,
            ParentName = student.ParentName,
            Results = _dataContext.Results.Select(r=> new GetResultDTO()
            {
                Id = r.Id,
                StudentId = r.StudentId,
                SubjectId = r.SubjectId,
                ExamId = r.ExamId,
                Marks = r.Marks
            }).ToList()
        };
        if (response == null) return new GetStudentDTO();
        return response;
    }

    public async Task<List<GetStudentDTO>> GetStudents()
    {
        var students = await _dataContext.Students.Select(st => new GetStudentDTO()
        {
            Id = st.Id,
            Email = st.Email,
            Password = st.Password,
            Name = st.Name,
            DOB = st.DOB,
            Sex = st.Sex,
            Address = st.Address,
            Phone = st.Phone,
            DateOfJoin = st.DateOfJoin,
            ParentName = st.ParentName,
            Results = _dataContext.Results.Select(r=> new GetResultDTO()
            {
                Id = r.Id,
                StudentId = r.StudentId,
                SubjectId = r.SubjectId,
                ExamId = r.ExamId,
                Marks = r.Marks
            }).ToList()
        }).ToListAsync();
        if (students == null) return new List<GetStudentDTO>();
        return students;
    }

    public async Task<string> UpdateStudent(UpdateStudentDTO updateStudentDTO)
    {
        var student = await _dataContext.Students.FindAsync(updateStudentDTO.Id);
        student.Id = updateStudentDTO.Id;
        student.Email = updateStudentDTO.Email;
        student.Password = updateStudentDTO.Password;
        student.Name = updateStudentDTO.Name;
        student.DOB = DateTime.MinValue;
        student.Sex = updateStudentDTO.Sex;
        student.Address = updateStudentDTO.Address;
        student.Phone = updateStudentDTO.Phone;
        student.ParentName = updateStudentDTO.ParentName;
        await _dataContext.SaveChangesAsync();
        return "Student updated!";
    }

}
