using System;
using System.Collections.Generic;

namespace Galery;

public partial class Time
{
    public int Id { get; set; }

    public string? Time1 { get; set; }

    public virtual ICollection<Paint> Paints { get; } = new List<Paint>();
}
