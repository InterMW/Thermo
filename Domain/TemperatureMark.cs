namespace Domain;
public class TemperatureMark
{
    public string HostName {get; set;} = string.Empty;

    public string PartName {get; set;} = string.Empty;

    public DateTime Timestamp {get; set;}

    public double Temperature {get; set;}
}
