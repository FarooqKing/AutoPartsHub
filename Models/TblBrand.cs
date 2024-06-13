using System;
using System.Collections.Generic;

namespace AutoHubFYP.Models;

public partial class TblBrand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public string BrandTitle { get; set; } = null!;

    public string BrandShortName { get; set; } = null!;

    public string? BrandDescription { get; set; }

    public string? BrandImage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool MDelete { get; set; }

    public virtual ICollection<TblItem> TblItems { get; set; } = new List<TblItem>();
}
