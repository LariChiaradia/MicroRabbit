using MicroRabbit.Infra.IoC;
using MicroRabbit.Transfer.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transfer Microservice", Version = "v1" });
});

var mySqlConnection = builder.Configuration.GetConnectionString("TransferConnection");

builder.Services.AddDbContext<TransferDbContext>(options =>
{
    options.UseMySql(mySqlConnection,
        ServerVersion.AutoDetect(mySqlConnection));
});

DependencyContainer.RegisterServices(builder.Services);

var app = builder.Build();

DependencyContainer.ConfigureBus(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice V1");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
