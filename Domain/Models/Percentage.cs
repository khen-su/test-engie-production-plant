using System;
namespace Domain.Models
{
    public class Percentage
    {
        public decimal Value { get; set; }
        public Percentage(decimal value)
        {
            if (value < 0 || value > 1) throw new Exception("invalid value");
            Value = value;
        }
    }
}
