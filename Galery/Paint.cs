using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Galery;

public partial class Paint
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? PhotoPaint { get; set; }
    public BitmapImage PhotoBytes {
        get
        {
            return new BitmapImage(new Uri(PhotoPaint, UriKind.RelativeOrAbsolute));
        }
    }

    public int? Genre { get; set; }

    public int? Time { get; set; }

    public int? DateOfCreate { get; set; }

    public string? Material { get; set; }

    public string? Location { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<Crosscreatorpaint> Crosscreatorpaints { get; } = new List<Crosscreatorpaint>();

    public virtual Genre? GenreNavigation { get; set; }

    public virtual Time? TimeNavigation { get; set; }
}
