﻿using System;
using System.Collections.Generic;

namespace AutoHubFYP.Models;

public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string CategoryTital { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public string? CategoryImage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool MDelete { get; set; }

    public virtual ICollection<TblItemCategory> TblItemCategories { get; set; } = new List<TblItemCategory>();
}
