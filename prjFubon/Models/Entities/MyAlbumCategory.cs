using System;
using System.Collections.Generic;

namespace prjFubon.Models.Entities;

public partial class MyAlbumCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
}
