using Microsoft.AspNetCore.Mvc;
using SensorTestData.Models;

namespace SensorTestData.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorsController : ControllerBase
{
    private static readonly Random _random = new();

    private static string GetCurrentDateTimeDSPD() => 
        DateTime.Now.ToString("dd-MM-yyyy,HH:mm:ss");

    private static string GetCurrentDateTimeIWS() => 
        DateTime.Now.ToString("dd-MM-yyyy,HH:mm:ss.fff");

    private static string GetCurrentDateTimeMUEKS() => 
        DateTime.Now.ToString("dd-MM-yyyy,HH:mm:ss");

    private static double RandomDouble(double min, double max) => 
        _random.NextDouble() * (max - min) + min;

    private static int RandomInt(int min, int max) => 
        _random.Next(min, max + 1);

    /// <summary>
    /// DSPD - Датчик состояния проезжей части (Дорожный Сенсор Покрытия Дороги)
    /// </summary>
    [HttpGet("DSPD")]
    [ProducesResponseType(typeof(DSPD), 200)]
    public ActionResult<DSPD> GetDSPD()
    {
        var data = new DSPD
        {
            Packet = new DSPDPacket
            {
                Grip = RandomDouble(0.1, 1.0),
                Shake = RandomDouble(0.0, 0.1),
                UPower = RandomDouble(10.0, 15.0),
                Datatime = GetCurrentDateTimeDSPD(),
                TempCase = RandomDouble(-10.0, 5.0),
                TempRoad = RandomDouble(-10.0, 5.0),
                HeightH2O = RandomDouble(0.0, 0.5),
                HeightIce = RandomDouble(0.0, 3.0),
                HeightSnow = RandomDouble(0.0, 0.5),
                PercentIce = RandomDouble(0.0, 100.0),
                PercentPGM = RandomDouble(0.0, 20.0),
                RoadStatus = RandomInt(0, 15),
                AngleToRoad = RandomDouble(0.0, 90.0),
                TempFrizePGM = RandomDouble(-5.0, 5.0),
                NeedCalibration = RandomInt(0, 1),
                DistanceToSurface = RandomDouble(10000.0, 15000.0)
            }
        };

        return Ok(data);
    }

    /// <summary>
    /// IWS - Интеллектуальная погодная станция
    /// </summary>
    [HttpGet("IWS")]
    [ProducesResponseType(typeof(IWS), 200)]
    public ActionResult<IWS> GetIWS()
    {
        var data = new IWS
        {
            Packet = new IWSPacket
            {
                KSP = RandomInt(0, 20),
                Roll = RandomDouble(-5.0, 5.0),
                Pitch = RandomDouble(-5.0, 5.0),
                Altitude = RandomInt(0, 500),
                DewPoint = RandomDouble(-10.0, 5.0),
                Humidity = RandomDouble(0.0, 100.0),
                Latitude = RandomDouble(55.0, 56.0),
                Datatime = GetCurrentDateTimeIWS(),
                GPSSpeed = RandomDouble(0.0, 100.0),
                Longitude = RandomDouble(37.0, 38.0),
                WeAreFine = RandomInt(0, 1),
                WindSpeed = RandomDouble(0.0, 20.0),
                WindVSound = RandomDouble(330.0, 340.0),
                PressureHPa = RandomDouble(950.0, 1050.0),
                SupplyVoltage = RandomDouble(40.0, 50.0),
                WindDirection = RandomDouble(0.0, 360.0),
                EnvTemperature = RandomDouble(-10.0, 5.0),
                PressureMmHg = RandomDouble(700.0, 800.0),
                PressureQNHHPa = RandomDouble(980.0, 1020.0),
                AccelerationStDev = RandomDouble(0.0, 1.0),
                PrecipitationType = RandomInt(0, 200),
                PrecipitationElaps = RandomInt(0, 200),
                PrecipitationPeriod = RandomInt(0, 1440),
                PrecipitationQuantity = RandomDouble(0.0, 10.0),
                PrecipitationIntensity = RandomDouble(0.0, 5.0)
            }
        };

        return Ok(data);
    }

    /// <summary>
    /// DOV - Датчик оптической видимости (Датчик Освещенности и Видимости)
    /// </summary>
    [HttpGet("DOV")]
    [ProducesResponseType(typeof(DOV), 200)]
    public ActionResult<DOV> GetDOV()
    {
        var data = new DOV
        {
            Packet = new DOVPacket
            {
                BrightFlag = RandomInt(0, 1), // значения 1 или 0
                VisibleRange = RandomDouble(0.0, 3000.0) // от 0 до 3000.00
            }
        };

        return Ok(data);
    }

    /// <summary>
    /// DUST - Датчик пыли и частиц в воздухе
    /// </summary>
    [HttpGet("DUST")]
    [ProducesResponseType(typeof(DUST), 200)]
    public ActionResult<DUST> GetDUST()
    {
        var pm10 = RandomDouble(5.0, 20.0);
        var pm1 = RandomDouble(3.0, 15.0);
        var pm25 = RandomDouble(5.0, 18.0);

        var data = new DUST
        {
            Packet = new DUSTPacket
            {
                PM10Act = Math.Round(pm10, 2),
                PM10Awg = Math.Round(pm10 + RandomDouble(-1.0, 1.0), 2),
                PM10Act2 = Math.Round(pm1, 2),
                PM10Awg2 = Math.Round(pm1 + RandomDouble(-0.5, 0.5), 2),
                PM25Act = Math.Round(pm25, 2),
                PM25Awg = Math.Round(pm25 + RandomDouble(-0.8, 0.8), 2),
                FlowProbe = RandomDouble(0.5, 2.0),
                LaserStatus = RandomInt(500, 700),
                HumidityProbe = RandomDouble(0.0, 50.0),
                SupplyVoltage = RandomDouble(40.0, 50.0),
                TemperatureProbe = RandomDouble(20.0, 35.0)
            }
        };

        return Ok(data);
    }

    /// <summary>
    /// MUEKS - Многоканальное устройство управления и контроля сенсоров
    /// </summary>
    [HttpGet("MUEKS")]
    [ProducesResponseType(typeof(MUEKS), 200)]
    public ActionResult<MUEKS> GetMUEKS()
    {
        var data = new MUEKS
        {
            Packet = new MUEKSPacket
            {
                IAKB = RandomDouble(0.0, 5.0),
                UAKB = RandomDouble(24.0, 30.0),
                WhAKB = RandomDouble(20.0, 80.0),
                Datatime = GetCurrentDateTimeMUEKS(),
                IOut12B = RandomDouble(0.0, 2.0),
                IOut48B = RandomDouble(0.0, 2.0),
                Sens220B = RandomInt(0, 1),
                UOut12B = RandomDouble(28.0, 32.0),
                VisibleRange = "err",
                UPowerIn12B = RandomDouble(28.0, 32.0),
                TemperatureBox = RandomDouble(20.0, 35.0),
                VS2kTemperature = "err",
                VS2kSpiderStatus = "err",
                VS2kRecvSoilFlag = "err",
                VS2kSendSoilFlag = "err",
                VS2kRecvSoilLevel = "err",
                VS2kSendSoilLevel = "err",
                VS2kRecvSoilRawLevel = "err",
                VS2kSendSoilRawLevel = "err"
            }
        };

        return Ok(data);
    }
}