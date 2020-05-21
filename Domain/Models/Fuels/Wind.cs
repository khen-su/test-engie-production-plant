using Domain.Models.Units;

namespace Domain.Models.Fuels
{
    public class Wind : Fuel
    {
        public decimal Intensity { get; set; }

        public Wind(Percentage intensity) : base(new ValidName("wind"), new PricePerUnitZero(), new RatioToWasteZero())
        {
            Intensity = intensity.Value;
        }
    }
}
