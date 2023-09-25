using Domain.DTOs.SubjectDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.SubjectServices;

public class SubjectService: ISubjectService
{
    private readonly DataContext _dataContext;


    public SubjectService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<string> AddSubject(AddSubjectDTO addSubjectDTO)
    {
        var subject = new Subject()
        {
            Name = addSubjectDTO.Name,
            Grade = addSubjectDTO.Grade,
            Description = addSubjectDTO.Description,
            ClassroomId = addSubjectDTO.ClassroomId
        };
        await _dataContext.Subjects.AddAsync(subject);
        _dataContext.SaveChanges();
        return "Subject added!";
    }

    public async Task<string> DeleteSubject(int id)
    {
        var subject = _dataContext.Subjects.Find(id);
        if(subject == null) return "Not exist!";
        _dataContext.Subjects.Remove(subject);
        await _dataContext.SaveChangesAsync();
        return "Subject deleted!";
    }

    public async Task<GetSubjectDTO> GetSubject(int id)
    {
        var subject = await _dataContext.Subjects.FindAsync(id);
        var response = new GetSubjectDTO()
        {
            Id = subject.Id,
            Grade = subject.Grade,
            Description = subject.Description,
            ClassroomId = subject.ClassroomId
        };
        return response;
    }

    public async Task<List<GetSubjectDTO>> GetSubjects()
    {
        var subjects = await _dataContext.Subjects.Select(s=> new GetSubjectDTO()
        {
            Id = s.Id,
            Grade = s.Grade,
            Description = s.Description,
            ClassroomId = s.ClassroomId
        }).ToListAsync();
        return subjects;
    }

    public async Task<string> UpdateSubject(UpdateSubjectDTO updateSubjectDTO)
    {
        var subject = await _dataContext.Subjects.FindAsync(updateSubjectDTO.Id);
        subject.Id = updateSubjectDTO.Id;
        subject.Grade = updateSubjectDTO.Grade;
        subject.Description = updateSubjectDTO.Description;
        subject.ClassroomId = updateSubjectDTO.ClassroomId;
        _dataContext.Subjects.Update(subject);
        await _dataContext.SaveChangesAsync();
        return "Subject updated!";
    }

}
