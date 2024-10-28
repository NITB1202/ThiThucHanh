using System;
using System.Collections.Generic;

namespace ThiThucHanh.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime Date { get; set; }

    public int Total { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
