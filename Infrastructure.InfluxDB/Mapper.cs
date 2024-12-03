using Domain;
using MelbergFramework.Infrastructure.InfluxDB;

namespace Infrastructure.InfluxDB;

public static class TemperatureMarkMapper
{
    public static InfluxDBDataModel ToDataModel(this TemperatureMark mark)
    {
        if(mark == null)
        {
       	    return null;
        }

	var result = new InfluxDBDataModel("node_data");

	result.Tags["hostname"] = mark.HostName;
    result.Measurement = "temperature";
	result.Fields["temperature"] = mark.Temperature;
	result.Tags["part"] = mark.PartName;
    result.Timestamp = mark.Timestamp;

	return result;
    }
}
