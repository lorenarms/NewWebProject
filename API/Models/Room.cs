using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Room
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Furniture> Furnitures { get; set; } = new List<Furniture>();
}
