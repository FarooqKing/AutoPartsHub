﻿namespace AutoPartsHub.Models
{
    public interface ISoftDeleteTable
    {
        DateTime? UpdatedAt { get; set; }
        int? UpdatedBy { get; set; }
        bool? mDelete { get; set; }
    }


    
}