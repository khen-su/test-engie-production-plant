using System;
namespace Domain.Models
{
    public class PositiveDecimal
    {
        public decimal Value { get;}
        public PositiveDecimal(decimal number)
        {
            if (number < 0) throw new Exception("number can't be lower than 0");
            Value = number;
        }
    }
}
