using Domain.DTOs.ResultDTOs;

namespace Infrastructure.Services.ResultServices;

public interface IResultService
{
    Task<List<GetResultDTO>> GetResultes();
    Task<GetResultDTO> GetResulte(int id);
    Task<string> AddResulte(AddResultDTO addResulteDTO);
    Task<string> UpdateResulte(UpdateResultDTO updateResulteDTO);
    Task<string> DeleteResulte(int id);
}
