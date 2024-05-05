using BusinessLogic.Managers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile(
    "appsettings." + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") + ".json"
)
.Build();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ManagerPaciente>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseExceptionMiddleware();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
.WriteTo.File(builder.Configuration.GetSection("log").Value, rollingInterval: RollingInterval.Day)
.CreateLogger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName.Equals("QA") || app.Environment.EnvironmentName.Equals("UAT"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
