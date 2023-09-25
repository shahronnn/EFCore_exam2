using Domain.DTOs.TeacherDTOs;

namespace Infrastructure.Services.TeacherServices;

public interface ITeacherService
{
    Task <List<GetTeacherDTO>> GetTeachers();
    Task <GetTeacherDTO> GetTeacher(int id);
    Task <string> AddTeacher(AddTeacherDTO addTeacherDTO);
    Task <string> UpdateTeacher(UpdateTeacherDTO updateTeacherDTO);
    Task <string> DeleteTeacher(int id);
}
