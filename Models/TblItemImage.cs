using System;
using System.Collections.Generic;

namespace AutoHubFYP.Models;

public partial class TblItemImage
{
    public int ItemImageId { get; set; }

    public string ItemImageName { get; set; } = null!;

    public string? ThumbailImage { get; set; }

    public string? NormalImage { get; set; }

    public bool? IsDefault { get; set; }

    public int? ItemId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool MDelete { get; set; }

    public string? BanerImage { get; set; }

    public virtual TblItem? Item { get; set; }
}
