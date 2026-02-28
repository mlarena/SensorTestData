using System.Text.Json.Serialization;

namespace SensorTestData.Models;

public class MUEKS
{
    [JsonPropertyName("Packet")]
    public MUEKSPacket Packet { get; set; } = new();

    [JsonPropertyName("Serial")]
    public string Serial { get; set; } = "Pinger_88:00:00:0B:88:CE:8B:28";
}

public class MUEKSPacket
{
    [JsonPropertyName("I_AKB")]
    public double IAKB { get; set; }

    [JsonPropertyName("U_AKB")]
    public double UAKB { get; set; }

    [JsonPropertyName("Wh_AKB")]
    public double WhAKB { get; set; }

    [JsonPropertyName("datatime")]
    public string Datatime { get; set; } = string.Empty;

    [JsonPropertyName("I_OUT_12B")]
    public double IOut12B { get; set; }

    [JsonPropertyName("I_OUT_48B")]
    public double IOut48B { get; set; }

    [JsonPropertyName("SENS_220B")]
    public int Sens220B { get; set; }

    [JsonPropertyName("U_OUT_12B")]
    public double UOut12B { get; set; }

    [JsonPropertyName("Visible_range")]
    public string VisibleRange { get; set; } = "err";

    [JsonPropertyName("U_POWER_IN_12B")]
    public double UPowerIn12B { get; set; }

    [JsonPropertyName("temperature_box")]
    public double TemperatureBox { get; set; }

    [JsonPropertyName("VS2k_temperature")]
    public string VS2kTemperature { get; set; } = "err";

    [JsonPropertyName("VS2k_spider_status")]
    public string VS2kSpiderStatus { get; set; } = "err";

    [JsonPropertyName("VS2k_recv_soil_flag")]
    public string VS2kRecvSoilFlag { get; set; } = "err";

    [JsonPropertyName("VS2k_send_soil_flag")]
    public string VS2kSendSoilFlag { get; set; } = "err";

    [JsonPropertyName("VS2k_recv_soil_level")]
    public string VS2kRecvSoilLevel { get; set; } = "err";

    [JsonPropertyName("VS2k_send_soil_level")]
    public string VS2kSendSoilLevel { get; set; } = "err";

    [JsonPropertyName("VS2k_recv_soil_raw_level")]
    public string VS2kRecvSoilRawLevel { get; set; } = "err";

    [JsonPropertyName("VS2k_send_soil_raw_level")]
    public string VS2kSendSoilRawLevel { get; set; } = "err";
}