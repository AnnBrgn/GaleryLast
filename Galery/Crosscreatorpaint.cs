using System;
using System.Collections.Generic;

namespace Galery;

public partial class Crosscreatorpaint
{
    public int IdCreator { get; set; }

    public int IdPaint { get; set; }

    public virtual Creator IdCreatorNavigation { get; set; } = null!;

    public virtual Paint IdPaintNavigation { get; set; } = null!;
}
