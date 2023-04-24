using System;
using System.Collections.Generic;

namespace Galery;

public partial class Creator
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Genre { get; set; }

    public virtual Genre? GenreNavigation { get; set; }
}
