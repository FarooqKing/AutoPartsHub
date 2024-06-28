using System;
using System.Collections.Generic;

namespace AutoPartsHub.Models;

public partial class TblItemSize
{
    public int SizeId { get; set; }

    public int? ItemId { get; set; }

    public string SizeName { get; set; } = null!;

    public decimal? SizeExtraAmount { get; set; }

    public bool? IsDefaultSize { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool MDelete { get; set; }

    public virtual TblItem? Item { get; set; }
}
