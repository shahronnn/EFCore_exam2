using Domain.DTOs.SubjectDTOs;

namespace Infrastructure.Services.SubjectServices;

public interface ISubjectService
{
    Task<List<GetSubjectDTO>> GetSubjects();
    Task<GetSubjectDTO> GetSubject(int id);
    Task<string> AddSubject(AddSubjectDTO addSubjectDTO);
    Task<string> UpdateSubject(UpdateSubjectDTO updateSubjectDTO);
    Task<string> DeleteSubject(int id);
}
