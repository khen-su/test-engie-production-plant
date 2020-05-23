using System;
using Domain.Models.Fuels;

namespace Domain.Builders.Interface
{
    public interface IResourceBuilder
    {
        Gas BuildGasFuel(decimal price, decimal co2);
        Kerosine BuildKerosineFuel(decimal price);
        Wind BuildWindFuel(decimal intensity);
    }
}
