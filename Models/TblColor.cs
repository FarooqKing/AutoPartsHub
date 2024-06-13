using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoHubFYP.Models;

public partial class TblColor
{
    public int ColorId { get; set; }

    [Required(ErrorMessage = "Item is required")]
    public int ItemId { get; set; }

    [Required(ErrorMessage = "Color Name is required")]
    public string ColorName { get; set; }

    [Display(Name = "Extra Amount")]
    public decimal? ColorExtraAmount { get; set; }

    [Display(Name = "Is Default")]
    public bool? IsDefaulColor { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdateBy { get; set; }

    public bool MDelete { get; set; }

    public virtual TblItem Item { get; set; } = null!;
}
