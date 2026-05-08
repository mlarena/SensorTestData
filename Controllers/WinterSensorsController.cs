using Microsoft.AspNetCore.Mvc;

namespace SensorTestData.Controllers;

[Route("api/winter")]
public class WinterSensorsController : BaseSmoothSensorsController
{
    protected override double GetMin(string key) => key switch
    {
        "Temp" => -40.0,
        "Grip" => 0.1,
        "Hum" => 60.0,
        "Press" => 730.0,
        "Vis" => 500.0,
        "UAKB" => 22.0,
        _ => 0.0
    };

    protected override double GetMax(string key) => key switch
    {
        "Temp" => 5.0,
        "Grip" => 0.5,
        "Hum" => 95.0,
        "Press" => 760.0,
        "Vis" => 2000.0,
        "UAKB" => 26.0,
        "Wind" => 25.0,
        "PM10" => 20.0,
        "PM25" => 15.0,
        "PM1" => 10.0,
        "Ice" => 5.0,
        "Snow" => 10.0,
        _ => 100.0
    };
}
