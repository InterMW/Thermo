using Domain;

namespace Infrastructure.RepositoryCore;

public interface ITemperatureRepository
{
    Task MarkTemperature(TemperatureMark mark);
}
