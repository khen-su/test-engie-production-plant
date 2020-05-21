using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class ProductionPipeline
    {
        public Queue<ProductionOutput> Outputs { get; set; }
    }
}
