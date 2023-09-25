using Domain.DTOs.StudentDTOs;

namespace Infrastructure.Services.StudentServices;

public interface IStudentService
{
    Task<List<GetStudentDTO>> GetStudents();
    Task<GetStudentDTO> GetStudent(int id);
    Task<string> AddStudent(AddStudentDTO addStudentDTO);
    Task<string> UpdateStudent(UpdateStudentDTO updateStudentDTO);
    Task<string> DeleteStudent(int id);
}
