﻿using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
