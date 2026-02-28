using System.Text.Json.Serialization;

namespace SensorTestData.Models;

public class IWS
{
    [JsonPropertyName("Packet")]
    public IWSPacket Packet { get; set; } = new();

    [JsonPropertyName("Serial")]
    public string Serial { get; set; } = "IWS_9F:6B:DC:B2";
}

public class IWSPacket
{
    [JsonPropertyName("KSP")]
    public int KSP { get; set; }

    [JsonPropertyName("Roll")]
    public double Roll { get; set; }

    [JsonPropertyName("Pitch")]
    public double Pitch { get; set; }

    [JsonPropertyName("Altitude")]
    public int Altitude { get; set; }

    [JsonPropertyName("DewPoint")]
    public double DewPoint { get; set; }

    [JsonPropertyName("Humidity")]
    public double Humidity { get; set; }

    [JsonPropertyName("Latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("datatime")]
    public string Datatime { get; set; } = string.Empty;

    [JsonPropertyName("GPS_speed")]
    public double GPSSpeed { get; set; }

    [JsonPropertyName("Longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("WeAreFine")]
    public int WeAreFine { get; set; }

    [JsonPropertyName("WindSpeed")]
    public double WindSpeed { get; set; }

    [JsonPropertyName("WindVSound")]
    public double WindVSound { get; set; }

    [JsonPropertyName("Pressure_hPa")]
    public double PressureHPa { get; set; }

    [JsonPropertyName("SupplyVoltage")]
    public double SupplyVoltage { get; set; }

    [JsonPropertyName("WindDirection")]
    public double WindDirection { get; set; }

    [JsonPropertyName("EnvTemperature")]
    public double EnvTemperature { get; set; }

    [JsonPropertyName("Pressure_mm_hg")]
    public double PressureMmHg { get; set; }

    [JsonPropertyName("Pressure_QNH_hPa")]
    public double PressureQNHHPa { get; set; }

    [JsonPropertyName("AccelerationStDev")]
    public double AccelerationStDev { get; set; }

    [JsonPropertyName("PrecipitationType")]
    public int PrecipitationType { get; set; }

    [JsonPropertyName("PrecipitationElaps")]
    public int PrecipitationElaps { get; set; }

    [JsonPropertyName("PrecipitationPeriod")]
    public int PrecipitationPeriod { get; set; }

    [JsonPropertyName("PrecipitationQuantity")]
    public double PrecipitationQuantity { get; set; }

    [JsonPropertyName("PrecipitationIntensity")]
    public double PrecipitationIntensity { get; set; }
}