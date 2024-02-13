using FrontEnd.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models.DTOs;

namespace FrontEnd.Pages.Rooms
{
    public class RoomsBase : ComponentBase
    {
        [Inject]
        IRoomService RoomService { get; set; }

        public IEnumerable<RoomDTO> Rooms { get; set; }
        public bool LoadFailed = false;
        public string Message { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Rooms = await RoomService.GetRooms();
                if (Equals(Rooms, Enumerable.Empty<RoomDTO>()))
                {
                    throw new Exception("Load failed!");
                }
            }
            catch (Exception ex)
            {
                LoadFailed = true;
                
                Message = $"{RoomService.GetMessage()} - {ex.Message}";
            }
            
        }
    }
}
