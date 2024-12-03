using Domain;
using Infrastructure.RepositoryCore;
using MelbergFramework.Infrastructure.InfluxDB;

namespace Infrastructure.InfluxDB;

public class TemperatureMarkRepository : BaseInfluxDBRepository<ThermalContext>,
	ITemperatureRepository
{
    public TemperatureMarkRepository(ThermalContext context) : base(context) {}

    public Task MarkTemperature(TemperatureMark mark) =>
        Context.WritePointAsync(mark.ToDataModel(),"node_data","Inter");
}
