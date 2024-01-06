using System;
using System.Collections.Generic;

namespace prjFubon.Models.Entities;

public partial class MyAlbum
{
    public int Id { get; set; }

    public string PicName { get; set; } = null!;

    public byte[] Image { get; set; } = null!;

    public int CategoryId { get; set; }
}
