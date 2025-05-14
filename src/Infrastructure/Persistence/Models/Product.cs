using System;
using System.Collections.Generic;

namespace tarea9_DAEA.src.Infrastructure.Persistence.Models;

public partial class Product
{
    public ulong ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }
}
