using System;
using System.Collections.Generic;

namespace TB_.WebApi.Database.AppDbContextModels;

public partial class TblProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public DateTime? ModifyDateTime { get; set; }

    public bool IsDeleted { get; set; }
}
