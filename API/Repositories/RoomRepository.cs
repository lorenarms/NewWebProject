using API.Data;
using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HomeFurnishingsDbContext _context;

        public RoomRepository(HomeFurnishingsDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }
    }
}
