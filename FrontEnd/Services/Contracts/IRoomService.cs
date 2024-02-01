using Models.DTOs;

namespace FrontEnd.Services.Contracts
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetRooms();
    }
}
