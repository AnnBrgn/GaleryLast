using System;
using System.Collections.Generic;

namespace Galery;

public partial class Genre
{
    public int Id { get; set; }

    public string Genre1 { get; set; } = null!;

    public virtual ICollection<Creator> Creators { get; } = new List<Creator>();

    public virtual ICollection<Paint> Paints { get; } = new List<Paint>();
}
