using System;
using System.Collections.Generic;

namespace AutoPartsHub.Models;

public partial class TblColor
{
    public int ColorId { get; set; }

    public int? ItemId { get; set; }

    public string ColorName { get; set; } = null!;

    public decimal? ColorExtraAmount { get; set; }

    public bool? IsDefaultColor { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdateBy { get; set; }

    public bool MDelete { get; set; }

    public virtual TblItem? Item { get; set; }
}
