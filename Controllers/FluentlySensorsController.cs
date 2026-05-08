using Microsoft.AspNetCore.Mvc;

namespace SensorTestData.Controllers;

[Route("api/fluently")]
public class FluentlySensorsController : BaseSmoothSensorsController
{
    protected override double GetMin(string key) => key switch
    {
        "Temp" => -10.0,
        "Grip" => 0.6,
        "Hum" => 40.0,
        "Press" => 740.0,
        "Vis" => 1500.0,
        "UAKB" => 24.0,
        _ => 0.0
    };

    protected override double GetMax(string key) => key switch
    {
        "Temp" => 25.0,
        "Grip" => 0.9,
        "Hum" => 80.0,
        "Press" => 770.0,
        "Vis" => 3000.0,
        "UAKB" => 28.0,
        "Wind" => 15.0,
        "PM10" => 30.0,
        "PM25" => 25.0,
        "PM1" => 20.0,
        _ => 100.0
    };
}
