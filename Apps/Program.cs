
using Apps.Configs;
using Apps.Models.Context;
using Apps.Services;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
builder.Services.AddScoped<ICrudRabbitService, CrudRabbitService>();

//Confgi Filter Validation
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//Config Masstransit
builder.Services.AddMassTransit(config => {

    config.AddConsumer<WorkerService>();

    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(appConfig!.RabbiHost);

        cfg.ReceiveEndpoint(appConfig.RabbitQueue!, c => {
            c.ConfigureConsumer<WorkerService>(ctx);
        });

        cfg.PrefetchCount = 1;
        cfg.ConcurrentMessageLimit = 1;
    });

});

//Config Controller
builder.Services.AddControllers(option =>
{
    option.Filters.Add(typeof(ValidateModelResponse));
}).AddFluentValidation(v =>
{
    v.ImplicitlyValidateChildProperties = true;
    v.ImplicitlyValidateRootCollectionElements = true;
    v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

//Config Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Apply MigrateDb
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
