﻿using System;
using System.Collections.Generic;

namespace NorthwindOriginalRestApi2.Models
{
    public partial class CategorySalesFor1997
    {
        public long Rowid { get; set; }
        public string CategoryName { get; set; } = null!;
        public decimal? CategorySales { get; set; }
    }
}