using Domain.DTOs.ClassroomDTOs;

namespace Infrastructure.Services.ClassroomServices;

public interface IClassroomService
{
    Task<List<GetClassroomDTO>> GetClassrooms();
    Task<GetClassroomDTO> GetClassroom(int id);
    Task<string> AddClassroom(AddClassroomDTO addClassroomDTO);
    Task<string> UpdateClassroom(UpdateClassroomDTO updateClassroomDTO);
    Task<string> DeleteClassroom(int id);
}
