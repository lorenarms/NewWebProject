using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Furniture
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual Room Room { get; set; }
}
