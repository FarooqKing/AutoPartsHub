using System;
using System.Collections.Generic;

namespace AutoHubFYP.Models;

public partial class TblOrdersMain
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public decimal GrandTotal { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? PaidAmount { get; set; }

    public int? PaymentId { get; set; }

    public string PaymentType { get; set; } = null!;

    public decimal ShippingAmount { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Email { get; set; }

    public int PhoneNo { get; set; }

    public int? CountryId { get; set; }

    public int? ProvinceId { get; set; }

    public int? CityId { get; set; }

    public string DeliveryAddress { get; set; } = null!;

    public bool Remarks { get; set; }

    public DateTime? DeliverDays { get; set; }

    public int? PostelCode { get; set; }

    public int? StatesId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? Createdby { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool MDelete { get; set; }

    public virtual TblCity? City { get; set; }

    public virtual TblCountry? Country { get; set; }

    public virtual TblProvince? Province { get; set; }

    public virtual TblStatus? States { get; set; }

    public virtual TblUser User { get; set; } = null!;
}
