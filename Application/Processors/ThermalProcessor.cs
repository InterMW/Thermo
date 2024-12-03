using Domain;
using DomainService;
using MelbergFramework.Infrastructure.Rabbit.Consumers;
using MelbergFramework.Infrastructure.Rabbit.Messages;
using MelbergFramework.Infrastructure.Rabbit.Translator;

namespace Application.Processor;

public class ThermalProcessor(
        IJsonToObjectTranslator<TemperatureMessage> translator,
        IThermalDomainService domainService,
        ILogger<ThermalProcessor> logger) : IStandardConsumer
{
    public async Task ConsumeMessageAsync(Message message, CancellationToken ct) 
    {
        var dto = translator.Translate(message);

        foreach ( var mark in dto.Temperatures.Select(_ => new TemperatureMark{ HostName = dto.HostName, Timestamp = dto.Timestamp, PartName = _.PartName, Temperature = _.Temperature}))
        {
            await domainService.MarkTemperature(mark);
        }

        logger.LogInformation("Logged temps for {_host}", dto.HostName);
    }
}

public class TemperatureMessage : StandardMessage 
{
    public string HostName {get;set;} = string.Empty;

    public DateTime Timestamp {get; set;}
    
    public TemperatureDetail[] Temperatures {get; set;} = [];

    public override string GetRoutingKey() => "temperature.placeholder";
}

public class TemperatureDetail
{
    public string PartName {get; set;} = string.Empty;

    public double Temperature {get; set;}
}
