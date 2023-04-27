using System;
using System.Collections.Generic;

namespace Galery;

public partial class Paint
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? PhotoPaint { get; set; }

    public int? Genre { get; set; }

    public int? Time { get; set; }

    public int? DateOfCreate { get; set; }

    public string? Material { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Crosscreatorpaint> Crosscreatorpaints { get; } = new List<Crosscreatorpaint>();

    public virtual Genre? GenreNavigation { get; set; }

    public virtual Time? TimeNavigation { get; set; }
}
