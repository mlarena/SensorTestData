using System.Text.Json.Serialization;

namespace SensorTestData.Models;

public class DUST
{
    [JsonPropertyName("Packet")]
    public DUSTPacket Packet { get; set; } = new();

    [JsonPropertyName("Serial")]
    public string Serial { get; set; } = "Dust_41:39:31:35:30:08:0E:08";
}

public class DUSTPacket
{
    [JsonPropertyName("PM10_act")]
    public double PM10Act { get; set; }

    [JsonPropertyName("PM10_awg")]
    public double PM10Awg { get; set; }

    [JsonPropertyName("PM1.0_act")]
    public double PM10Act2 { get; set; }

    [JsonPropertyName("PM1.0_awg")]
    public double PM10Awg2 { get; set; }

    [JsonPropertyName("PM2.5_act")]
    public double PM25Act { get; set; }

    [JsonPropertyName("PM2.5_awg")]
    public double PM25Awg { get; set; }

    [JsonPropertyName("Flow_probe")]
    public double FlowProbe { get; set; }

    [JsonPropertyName("Laser_status")]
    public int LaserStatus { get; set; }

    [JsonPropertyName("Humidity_probe")]
    public double HumidityProbe { get; set; }

    [JsonPropertyName("Supply_voltage")]
    public double SupplyVoltage { get; set; }

    [JsonPropertyName("Temperature_probe")]
    public double TemperatureProbe { get; set; }
}