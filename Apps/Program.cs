
using Apps.Configs;
using Apps.Models.Context;
using Apps.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Config Env
builder.Services.Configure<AppConfig>(builder.Configuration);
AppConfig? appConfig = builder.Configuration.Get<AppConfig>();

//Config MariaDb
builder.Services.AddDbContext<DataDbContext>(options =>
{
    options.UseMySql(appConfig.MariaDbConnectionString, ServerVersion.AutoDetect(appConfig.MariaDbConnectionString));
});

//Config Automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Config Dependency Injection
builder.Services.AddScoped<ICrudService, CrudService>();

//Config Controller
builder.Services.AddControllers();

//Config Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
