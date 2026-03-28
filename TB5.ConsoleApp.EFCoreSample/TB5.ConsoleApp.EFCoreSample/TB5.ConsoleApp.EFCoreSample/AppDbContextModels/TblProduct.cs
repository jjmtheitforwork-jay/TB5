using System;
using System.Collections.Generic;

namespace TB5.ConsoleApp.EFCoreSample.AppDbContextModels;

public partial class TblProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;
}
