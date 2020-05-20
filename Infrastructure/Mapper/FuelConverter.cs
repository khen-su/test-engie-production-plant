using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Builders;
using Domain.Models;
using Domain.Models.Fuels;
using Domain.Models.Units;
using Domain.ViewModels;

namespace Infrastructure.Mapper
{
    public class FuelConverter: IModelConverter<List<Fuel>, FuelViewModel>
    {
        ResourceBuilder ResourceBuilder = new ResourceBuilder();
         public List<Fuel> ToModel(FuelViewModel persisted)
        {
            return new List<Fuel>()
            {
                ResourceBuilder.BuildGasFuel(persisted.Gas, persisted.Co2),
                ResourceBuilder.BuildKerosineFuel(persisted.Kerosine)
            };
        }

        public FuelViewModel ToViewModel(List<Fuel> model)
        {
            throw new NotImplementedException();
        }
    }
}
