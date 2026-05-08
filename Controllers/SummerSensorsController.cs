using Microsoft.AspNetCore.Mvc;

namespace SensorTestData.Controllers;

[Route("api/summer")]
public class SummerSensorsController : BaseSmoothSensorsController
{
    protected override double GetMin(string key) => key switch
    {
        "Temp" => 20.0,
        "Grip" => 0.8,
        "Hum" => 30.0,
        "Press" => 750.0,
        "Vis" => 2500.0,
        "UAKB" => 25.0,
        _ => 0.0
    };

    protected override double GetMax(string key) => key switch
    {
        "Temp" => 45.0,
        "Grip" => 1.0,
        "Hum" => 60.0,
        "Press" => 780.0,
        "Vis" => 5000.0,
        "UAKB" => 29.0,
        "Wind" => 10.0,
        "PM10" => 50.0,
        "PM25" => 40.0,
        "PM1" => 30.0,
        _ => 100.0
    };
}
