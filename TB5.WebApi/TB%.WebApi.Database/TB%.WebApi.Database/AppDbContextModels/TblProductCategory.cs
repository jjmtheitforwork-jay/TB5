using System;
using System.Collections.Generic;

namespace TB_.WebApi.Database.AppDbContextModels;

public partial class TblProductCategory
{
    public int ProductCategoryId { get; set; }

    public string ProductCategoryName { get; set; } = null!;
}
