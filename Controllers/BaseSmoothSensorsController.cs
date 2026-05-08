using Microsoft.AspNetCore.Mvc;
using SensorTestData.Models;
using System.Collections.Concurrent;

namespace SensorTestData.Controllers;

[ApiController]
public abstract class BaseSmoothSensorsController : ControllerBase
{
    protected static readonly Random _random = new();
    private static readonly ConcurrentDictionary<string, double> _lastValues = new();

    protected abstract double GetMin(string key);
    protected abstract double GetMax(string key);
    protected virtual double GetStep(string key) => (GetMax(key) - GetMin(key)) * 0.02; // Шаг 2% для максимальной плавности

    protected double GetSmoothDouble(string key)
    {
        double min = GetMin(key);
        double max = GetMax(key);
        double step = GetStep(key);

        // Используем уникальный ключ для каждого контроллера, чтобы у них были разные состояния
        string fullKey = $"{this.GetType().Name}_{key}";

        double lastValue = _lastValues.GetOrAdd(fullKey, _random.NextDouble() * (max - min) + min);
        
        double change = (_random.NextDouble() * 2 - 1) * step;
        double newValue = Math.Clamp(lastValue + change, min, max);
        
        _lastValues[fullKey] = newValue;
        return Math.Round(newValue, 4);
    }

    protected int GetSmoothInt(string key) => (int)Math.Round(GetSmoothDouble(key));

    protected string GetCurrentDateTimeDSPD() => DateTime.Now.ToString("dd-MM-yyyy,HH:mm:ss");
    protected string GetCurrentDateTimeIWS() => DateTime.Now.ToString("dd-MM-yyyy,HH:mm:ss.fff");
    protected string GetCurrentDateTimeMUEKS() => DateTime.Now.ToString("dd-MM-yyyy,HH:mm:ss");

    [HttpGet("DSPD")]
    public virtual ActionResult<DSPD> GetDSPD() => Ok(new DSPD { Packet = new DSPDPacket {
        Grip = GetSmoothDouble("Grip"),
        Shake = GetSmoothDouble("Shake"),
        UPower = GetSmoothDouble("UPower"),
        Datatime = GetCurrentDateTimeDSPD(),
        TempCase = GetSmoothDouble("Temp"),
        TempRoad = GetSmoothDouble("Temp"),
        HeightH2O = GetSmoothDouble("H2O"),
        HeightIce = GetSmoothDouble("Ice"),
        HeightSnow = GetSmoothDouble("Snow"),
        PercentIce = GetSmoothDouble("PercentIce"),
        PercentPGM = GetSmoothDouble("PercentPGM"),
        RoadStatus = GetSmoothInt("Status"),
        AngleToRoad = 45.0,
        TempFrizePGM = GetSmoothDouble("Temp") - 5,
        NeedCalibration = 0,
        DistanceToSurface = 12000.0
    }});

    [HttpGet("IWS")]
    public virtual ActionResult<IWS> GetIWS() => Ok(new IWS { Packet = new IWSPacket {
        KSP = GetSmoothInt("KSP"),
        Roll = GetSmoothDouble("Roll"),
        Pitch = GetSmoothDouble("Pitch"),
        Altitude = 200,
        DewPoint = GetSmoothDouble("Temp") - 2,
        Humidity = GetSmoothDouble("Hum"),
        Latitude = 55.7558,
        Datatime = GetCurrentDateTimeIWS(),
        GPSSpeed = 0,
        Longitude = 37.6173,
        WeAreFine = 1,
        WindSpeed = GetSmoothDouble("Wind"),
        WindVSound = 331.0,
        PressureHPa = GetSmoothDouble("Press") * 1.333,
        SupplyVoltage = 48.0,
        WindDirection = GetSmoothDouble("Dir"),
        EnvTemperature = GetSmoothDouble("Temp"),
        PressureMmHg = GetSmoothDouble("Press"),
        PressureQNHHPa = GetSmoothDouble("Press") * 1.333,
        AccelerationStDev = 0.01,
        PrecipitationType = 0,
        PrecipitationQuantity = GetSmoothDouble("Rain")
    }});

    [HttpGet("DOV")]
    public virtual ActionResult<DOV> GetDOV() => Ok(new DOV { Packet = new DOVPacket {
        BrightFlag = GetSmoothInt("Bright"),
        VisibleRange = GetSmoothDouble("Vis")
    }});

    [HttpGet("DUST")]
    public virtual ActionResult<DUST> GetDUST() => Ok(new DUST { Packet = new DUSTPacket {
        PM10Act = GetSmoothDouble("PM10"),
        PM10Awg = GetSmoothDouble("PM10"),
        PM10Act2 = GetSmoothDouble("PM1"),
        PM10Awg2 = GetSmoothDouble("PM1"),
        PM25Act = GetSmoothDouble("PM25"),
        PM25Awg = GetSmoothDouble("PM25"),
        FlowProbe = 1.0,
        LaserStatus = 600,
        HumidityProbe = GetSmoothDouble("Hum"),
        SupplyVoltage = 48.0,
        TemperatureProbe = GetSmoothDouble("Temp")
    }});

    [HttpGet("MUEKS")]
    public virtual ActionResult<MUEKS> GetMUEKS() => Ok(new MUEKS { Packet = new MUEKSPacket {
        IAKB = GetSmoothDouble("IAKB"),
        UAKB = GetSmoothDouble("UAKB"),
        WhAKB = 60.0,
        Datatime = GetCurrentDateTimeMUEKS(),
        IOut12B = 0.5,
        IOut48B = 0.5,
        Sens220B = 1,
        UOut12B = 30.0,
        UPowerIn12B = 30.0,
        TemperatureBox = GetSmoothDouble("Temp") + 10
    }});
}
