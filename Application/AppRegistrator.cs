using MelbergFramework.Application;
using MelbergFramework.Infrastructure.Rabbit;
using MelbergFramework.Infrastructure.InfluxDB;
using Infrastructure.RepositoryCore;
using Infrastructure.InfluxDB;
using DomainService;
using Application.Processor;

namespace Application;

public class AppRegistrator : Registrator
{
    public override void RegisterServices(IServiceCollection services)
    {
        RabbitModule.RegisterMicroConsumer<
            NodeThermalProcessor,
            NodeTemperatureMessage>(services, false);
        RabbitModule.RegisterMicroConsumer<
            ThermalProcessor,
            TemperatureMessage>(services, false);

        services.AddTransient<IThermalDomainService,ThermalDomainService>();

        InfluxDBDependencyModule.LoadInfluxDBRepository<ITemperatureRepository,TemperatureMarkRepository,ThermalContext>(services);
    }
}
