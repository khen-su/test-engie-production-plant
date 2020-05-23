using System.Collections.Generic;

namespace Domain.Models
{
    public class ProductionPipeline
    {
        public ProductionPipeline(Queue<ProductionOutput> outputs)
        {
            Outputs = outputs;
        }
        public Queue<ProductionOutput> Outputs { get;}
    }
}
