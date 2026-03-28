using System;
using System.Collections.Generic;

namespace TB5.ConsoleApp.EFCoreSample.AppDbContextModels;

public partial class TblProductCategory
{
    public int ProductCategoryId { get; set; }

    public string ProductCategoryName { get; set; } = null!;
}
