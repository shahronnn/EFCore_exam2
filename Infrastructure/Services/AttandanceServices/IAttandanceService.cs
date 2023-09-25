using Domain.DTOs.Attandance;

namespace Infrastructure.Services.AttandanceService;

public interface IAttandanceService
{
    Task<List<GetAttandanceDTO>> GetAttandances();
    Task<GetAttandanceDTO> GetAttandance(int id);
    Task<string> AddStudentAttandance(AddStudentAttandanceDTO addStudentAttandanceDTO);
    Task<string> AddTeacherAttandance(AddTeacherAttandanceDTO addTeacherAttandanceDTO);
    Task<string> UpdateAttandance(UpdateAttandanceDto updateAttandanceDto);
    Task<string> DeleteAttandance(int id);
}
