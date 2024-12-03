using Domain;
using Infrastructure.RepositoryCore;

namespace DomainService;

public interface IThermalDomainService
{
    Task MarkTemperature(TemperatureMark mark);
}

public class ThermalDomainService(ITemperatureRepository repository) : IThermalDomainService
{
    public Task MarkTemperature(TemperatureMark mark) => repository.MarkTemperature(mark);
}
