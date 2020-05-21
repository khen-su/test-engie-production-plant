using System;
namespace Domain.Models.Units
{
    public class EnergyBilling : Energy
    {
        public TimeInterval TimeInterval { get; }
        public EnergyBilling(Energy quantity, TimeInterval timeInterval) : base(quantity.Quantity, quantity.ErnergyUnit)
        {
            TimeInterval = timeInterval;
        }
    }


    public static class EnergyBillingUnitExtensions
    {
        public static EnergyBilling Convert(this EnergyBilling from, EnergyUnit energy, TimeIntervalUnit timeInterval)
        {
            decimal convertedScale = from.ErnergyUnit.Scale / energy.Scale;
            decimal convertedInterval = from.TimeInterval.Unit.Scale / timeInterval.Scale;

            decimal convertedValue = from.Quantity.Value * convertedScale * convertedInterval;

            return new EnergyBilling(new Energy(new PositiveDecimal(convertedValue), energy), new TimeInterval(new PositiveDecimal(1), timeInterval));
        }



    }
}
