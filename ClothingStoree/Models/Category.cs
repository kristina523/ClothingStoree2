using System;
using System.Collections.Generic;

namespace ClothingStoree.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
