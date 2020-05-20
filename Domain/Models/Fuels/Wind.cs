namespace Domain.Models.Fuels
{
    public class Wind
    {

        public float Intensity { get; set; }
        public Wind(Percentage intesity)
        {
            Intensity = intesity.Value;
        }

    }
}
