using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            try
            {
                var rooms = await _roomRepository.GetAllRooms();

                if (rooms == null)
                {
                    return NotFound();
                }

                var roomDTOs = new List<RoomDTO>();

                foreach (var room in rooms)
                {
                    RoomDTO newRoom = new RoomDTO
                    {
                        Name = room.Name,
                        Description = room.Description
                    };

                    roomDTOs.Add(newRoom);
                }



                return Ok(roomDTOs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("getRooms_sp")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsSp()
        {
            var rooms = await _roomRepository.GetAllRoomsSp();
            return Ok(rooms);
        }
    }
}
