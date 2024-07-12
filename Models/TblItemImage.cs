using System;
using System.Collections.Generic;

namespace AutoPartsHub.Models;

public partial class TblItemImage
{
    public int ItemImageId { get; set; }

    public string ItemImageName { get; set; } = null!;

    public string? ThumbnailImage { get; set; }

    public string? NormalImage { get; set; }

    public Boolean IsDefault { get; set; }

    public int? ItemId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool MDelete { get; set; }

    public string? BanerImage { get; set; }

    public virtual TblItem? Item { get; set; }
}
