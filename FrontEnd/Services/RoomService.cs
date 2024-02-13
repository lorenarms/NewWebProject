using System.Net.Http.Json;
using FrontEnd.Services.Contracts;
using Models.DTOs;

namespace FrontEnd.Services
{
    public class RoomService :IRoomService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RoomService> _logger;
        public string ErrorMessage { get; set; } = String.Empty;

        public RoomService(HttpClient httpClient, ILogger<RoomService> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<RoomDTO>> GetRooms()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Roomsg");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<RoomDTO>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<RoomDTO>>();
                }

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception("Error: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                _logger.LogError(ErrorMessage);
            }
            return Enumerable.Empty<RoomDTO>();
        }

        public string GetMessage()
        {
            return ErrorMessage;
        }
    }
}
