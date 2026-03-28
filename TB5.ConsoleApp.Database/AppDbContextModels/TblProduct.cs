using System;
using System.Collections.Generic;

namespace TB5.ConsoleApp.Database.AppDbContextModels;

public partial class TblProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public DateTime? CreatedDateTime { get; set; }
}
