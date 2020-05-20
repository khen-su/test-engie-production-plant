using System;
namespace Domain.Models.Units
{
    public class EnergyUnit : Unit
    {
        public static EnergyUnit megaWatt = new MegaWatt();
        public static EnergyUnit watt = new Watt();

        private EnergyUnit(string unit, PositiveDecimal scale) : base(unit, scale)
        {

        }

        private class MegaWatt : EnergyUnit
        {

            public MegaWatt() : base("MegaWatt", new PositiveDecimal(1000000))
            {

            }

        }

        private class Watt : EnergyUnit
        {

            public Watt() : base("Watt", new PositiveDecimal(1))
            {

            }

        }
    }

    public class Energy
    {
        public PositiveDecimal Quantity { get; }
        public EnergyUnit ErnergyUnit { get; }
        public Energy(PositiveDecimal quantity, EnergyUnit energyUnit)
        {
            Quantity = quantity;
            ErnergyUnit = energyUnit;
        }
    }
}
