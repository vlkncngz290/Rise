using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using UserService.Context;
using UserService.Repositories.Contact;
using UserService.Repositories.User;
using UserService.SyncDataService.Grpc;

var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<PostgresqlDbContext>(opt =>
    opt.UseNpgsql(config.GetConnectionString("RiceDatabase")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();


builder.Services.AddGrpc();
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

app.UseAuthorization();
app.MapGrpcService<GrpcReportsService>();

app.MapControllers();

app.Run();
