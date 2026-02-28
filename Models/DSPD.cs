using System.Text.Json.Serialization;

namespace SensorTestData.Models;

public class DSPD
{
    [JsonPropertyName("Packet")]
    public DSPDPacket Packet { get; set; } = new();

    [JsonPropertyName("Serial")]
    public string Serial { get; set; } = "DSPD_E1:40:50:03:EC:DE:E8:12";
}

public class DSPDPacket
{
    [JsonPropertyName("grip")]
    public double Grip { get; set; }

    [JsonPropertyName("Shake")]
    public double Shake { get; set; }

    [JsonPropertyName("U_POWER")]
    public double UPower { get; set; }

    [JsonPropertyName("datatime")]
    public string Datatime { get; set; } = string.Empty;

    [JsonPropertyName("temp_case")]
    public double TempCase { get; set; }

    [JsonPropertyName("temp_road")]
    public double TempRoad { get; set; }

    [JsonPropertyName("height_h2o")]
    public double HeightH2O { get; set; }

    [JsonPropertyName("height_ice")]
    public double HeightIce { get; set; }

    [JsonPropertyName("height_snow")]
    public double HeightSnow { get; set; }

    [JsonPropertyName("percent_ICE")]
    public double PercentIce { get; set; }

    [JsonPropertyName("percent_PGM")]
    public double PercentPGM { get; set; }

    [JsonPropertyName("road_status")]
    public int RoadStatus { get; set; }

    [JsonPropertyName("angle_to_road")]
    public double AngleToRoad { get; set; }

    [JsonPropertyName("temp_frize_PGM")]
    public double TempFrizePGM { get; set; }

    [JsonPropertyName("Need_calibration")]
    public int NeedCalibration { get; set; }

    [JsonPropertyName("distance_to_surface")]
    public double DistanceToSurface { get; set; }
}