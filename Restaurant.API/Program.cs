using Microsoft.AspNetCore.Diagnostics;
using Restaurant.Application.Extensions;
using Restaurant.Infrastructure.Extensions;
using Restaurant.Infrastructure.Seeders;
using Serilog;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((context, configuration) => 
	configuration.ReadFrom.Configuration(context.Configuration)
);

builder.Services.AddApplicaiton();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<ExceptionHandlerMiddleware>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();

app.UseMiddleware<ExceptionHandlerMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
