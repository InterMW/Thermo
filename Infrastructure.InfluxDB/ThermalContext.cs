using MelbergFramework.Infrastructure.InfluxDB;
using Microsoft.Extensions.Options;

namespace Infrastructure.InfluxDB;

public class ThermalContext :  DefaultContext
{
    public ThermalContext(
        IStandardClientFactory factory,
        IOptions<InfluxDBOptions<ThermalContext>> options) 
        : base(factory, options.Value){}
} 
