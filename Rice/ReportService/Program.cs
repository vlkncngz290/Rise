using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using ReportService.AsyncDataService;
using ReportService.Context;
using ReportService.Repositories.Report;
using ReportService.Repositories.ReportProducer;

var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<PostgresqlDbContext>(opt =>
    opt.UseNpgsql(config.GetConnectionString("RiceReportDatabase")));

builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportProducerRepository, ReportProducerRepository>();
builder.Services.AddSingleton<IHostedService, ReportRequestConsumerService>();

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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

app.Run();
