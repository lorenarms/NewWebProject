using System.Net.Http.Json;
using FrontEnd.Services.Contracts;
using Models.DTOs;

namespace FrontEnd.Services
{
    public class RoomService : IRoomService
    {
        private readonly HttpClient _httpClient;

        public RoomService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<RoomDTO>> GetRooms()
        {
            var response = await _httpClient.GetAsync($"/api/Rooms");

            return await response.Content.ReadFromJsonAsync<IEnumerable<RoomDTO>>();
        }
    }
}
