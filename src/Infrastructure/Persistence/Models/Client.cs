using System;
using System.Collections.Generic;

namespace tarea9_DAEA.src.Infrastructure.Persistence.Models;

public partial class Client
{
    public ulong ClientId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
}
