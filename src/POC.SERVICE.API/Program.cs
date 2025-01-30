
using POC.SERVICE.API.Configurations;
using POC.SERVICE.API.Interfaces;
using POC.SERVICE.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.AddApiConfiguration()
        .AddMediatRConfiguration()
        .AddDatabaseConfiguration()
        .AddAutoMapperConfiguration()
        .AddDependencyInjectionConfiguration();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application
builder.Services.AddScoped<IClientService, ClientService>();

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
