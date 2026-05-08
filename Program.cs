using Prometheus;
using Prometheus.SystemMetrics;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        options.JsonSerializerOptions.WriteIndented = false;
    });

// Добавляем системные метрики (CPU, Memory, Disk, etc.)
builder.Services.AddSystemMetrics();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
builder.Services.AddEndpointsApiExplorer();

// Конфигурация Swashbuckle Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Упрощаем: эндпоинт метрик будет доступен на всех настроенных портах
// Но так как мы настроили Kestrel на 9102, Prometheus сможет забирать их оттуда
app.MapMetrics();

// OpenAPI endpoint (Microsoft.AspNetCore.OpenApi)
app.MapOpenApi();

// Swashbuckle Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sensor Test Data API v1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

// Включаем сбор метрик HTTP-запросов (количество, длительность, коды ответов)
app.UseHttpMetrics();

app.UseAuthorization();
app.MapControllers();

app.Run();