using Domain.DTOs.ExamDTOs;

namespace Infrastructure.Services.ExamServices;

public interface IExamService
{
    Task<List<GetExamDTO>> GetExams();
    Task<GetExamDTO> GetExam(int id);
    Task<string> AddExam(AddExamDTO addExamDTO);
    Task<string> UpdateExam(UpdateExamDTO updateExamDTO);
    Task<string> DeleteExam(int id);
}
