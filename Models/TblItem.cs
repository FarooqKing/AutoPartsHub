﻿using System;
using System.Collections.Generic;

namespace AutoPartsHub.Models;

public partial class TblItem
{
    public int ItemId { get; set; }

    public string? ItemSlugs { get; set; }

    public string ItemName { get; set; } = null!;

    public decimal ItemPrice { get; set; }

    public decimal? Discount { get; set; }

    public bool? IsFeature { get; set; }

    public int? BrandId { get; set; }

    public string? Sku { get; set; }

    public string? DefaultImageUrl { get; set; }

    public string? ShortDescription { get; set; }

    public string? LongDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool MDelete { get; set; }

    public virtual TblBrand? Brand { get; set; }

    public virtual ICollection<TblColor> TblColors { get; set; } = new List<TblColor>();

    public virtual ICollection<TblItemImage> TblItemImages { get; set; } = new List<TblItemImage>();

    public virtual ICollection<TblItemSize> TblItemSizes { get; set; } = new List<TblItemSize>();

    public virtual ICollection<TblItemTag> TblItemTags { get; set; } = new List<TblItemTag>();

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();
}