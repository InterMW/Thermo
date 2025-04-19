using Domain;
using DomainService;
using MelbergFramework.Infrastructure.Rabbit.Consumers;
using MelbergFramework.Infrastructure.Rabbit.Messages;
using MelbergFramework.Infrastructure.Rabbit.Translator;

namespace Application.Processor;

public class NodeThermalProcessor(
        IJsonToObjectTranslator<NodeTemperatureMessage> translator,
        IThermalDomainService domainService,
        ILogger<ThermalProcessor> logger) : IStandardConsumer
{
    public async Task ConsumeMessageAsync(Message message, CancellationToken ct) 
    {

        var dto = translator.Translate(message);

        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
        var date = epoch.AddSeconds(dto.Timestamp);
        await domainService.MarkTemperature(new TemperatureMark { HostName = dto.HostName, Timestamp = date, PartName = "CPU", Temperature = dto.Temperature});

        logger.LogInformation("Logged temps for node {_host}", dto.HostName);
    }
}

public class NodeTemperatureMessage : StandardMessage 
{
    public string HostName {get;set;} = string.Empty;

    public long Timestamp {get; set;}
    
    public float Temperature {get; set;} 

    public override string GetRoutingKey() => "temperature.placeholder";
}
