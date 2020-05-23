using Domain;
using Domain.Builders;
using Domain.Builders.Interface;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace PowerPlantCodingChallenge
{
    public partial class Startup
    {
       public void ConfigureDI(IServiceCollection services)
        {

            services.AddSingleton<IMeritOrderLogic, MeritOrderLogic>();
            services.AddSingleton<IResourceBuilder, ResourceBuilder>();
            services.AddSingleton<IPowerPlantManager, PowerPlantManager>();
            services.AddSingleton<IPowerPlantBuilder, PowerPlantBuilder>();
        }
    }
}