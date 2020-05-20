using System;
namespace Domain.Models
{
    public class Percentage
    {
        public float Value { get; set; }
        public Percentage(float value)
        {
            if (value < 0 || value > 100) throw new Exception("invalid value");
            Value = value;
        }
    }
}
