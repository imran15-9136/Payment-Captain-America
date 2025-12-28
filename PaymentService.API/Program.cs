using Microsoft.Extensions.DependencyInjection;
using PaymentService.Infrastructure.Implementation;
using PaymentService.SharedKernel.Dto;
using PaymentService.SharedKernel.Interface;
using Scalar.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();



//service register

builder.Services.AddSingleton<IServiceBus, RabbitMqBus>();





var app = builder.Build();

try
{
	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		//app.MapOpenApi();
		app.MapScalarApiReference();
	}

	app.UseHttpsRedirection();

	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
catch(ReflectionTypeLoadException ex)
{
	Console.WriteLine("ReflectionTypeLoadException occurred:");
	foreach (var loaderEx in ex.LoaderExceptions)
	{
		Console.WriteLine(loaderEx?.Message);
		Console.WriteLine(loaderEx?.StackTrace);
		Console.WriteLine("---");
	}
	throw; // rethrow or handle as needed
}


