using API.Models;

namespace API.Repositories.Contracts
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<IEnumerable<Room>> GetAllRoomsSp();
    }
}
