using System;
using System.Collections.Generic;

namespace ThiThucHanh.Models;

public partial class InvoiceDetail
{
    public int DetailId { get; set; }

    public int InvoiceId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
