using System.Text.Json.Serialization;

namespace SensorTestData.Models;

public class DOV
{
    [JsonPropertyName("Packet")]
    public DOVPacket Packet { get; set; } = new();

    [JsonPropertyName("Serial")]
    public string Serial { get; set; } = "Visible_58:35:32:31:30:10:0C:04";
}

public class DOVPacket
{
    [JsonPropertyName("bright_flag")]
    public int BrightFlag { get; set; } // значения 1 или 0

    [JsonPropertyName("visible_range")]
    public double VisibleRange { get; set; } // от 0 до 3000.00
}