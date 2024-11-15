﻿using System;
using System.Collections.Generic;

namespace NorthwindOriginalRestApi2.Models
{
    public partial class ProductsDailySale
    {
        public long Rowid { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ProductName { get; set; } = null!;
        public double? DailySales { get; set; }
    }
}
