using S71500.RestApi.Application;
using S71500.RestApi.Application.Repositories;
using Siemens.Simatic.S7.Webserver.API.Services;
using Siemens.Simatic.S7.Webserver.API.Services.RequestHandling;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplication();
//builder.Services.AddDatabase(config["Database:ConnectionString"]!);

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var plcConnection = app.Services.GetRequiredService<IPlcConnectionFactory>();
var serviceFactory = app.Services.GetRequiredService<IApiServiceFactory>();
var ipAddress = config["PlcConnection:IPAddress"]!;
var username = config["PlcConnection:Username"]!;
var password = config["PlcConnection:Password"]!;

async Task<IApiRequestHandler> myTask()
{
    return await serviceFactory.GetApiHttpClientRequestHandlerAsync(ipAddress, username, password);
}

/*
async Task<IApiRequestHandler> myTask = new async Task<IApiRequestHandler>(() =>
{
    return serviceFactory.GetApiHttpClientRequestHandler(ipAddress, username, password);
});*/

var toInvoke = async () => await myTask();
if (plcConnection is PlcConnectionFactory plcConnectionFactory)
{
    await plcConnectionFactory.InitializeAsync(toInvoke);
}

//var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
//await dbInitializer.InitializeAsync();

app.Run();
