// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using PaymentCommendWorkerHost;
using PaymentCommendWorkerHost.Implementation;
using PaymentService.Infrastructure.Configuration;
using PaymentService.Infrastructure.Implementation;
using PaymentService.SharedKernel.Interface;

Console.WriteLine("Hello, World!");

var builder = Host.CreateApplicationBuilder(args);

var mongoSettings = new MongoSettings
{
	ConnectionString = "mongodb+srv://snewaj:182EH68BZUKYwBqj@cognitiveblaze.ug7mvjg.mongodb.net/?appName=CognitiveBlaze",
	DatabaseName = "PaymentDatabase"
};

builder.Services.AddSingleton<IMongoClient>(
	_ => new MongoClient(mongoSettings.ConnectionString));

builder.Services.AddScoped<IMongoDatabase>(sp =>
{
	var client = sp.GetRequiredService<IMongoClient>();
	var settings = sp.GetRequiredService<MongoSettings>();
	return client.GetDatabase(settings.DatabaseName);
});


builder.Services.AddSingleton<IMessageConsumer, MessageConsumer>();
builder.Services.AddTransient<ICommandHandler, CommandHandler>();
builder.Services.AddTransient<IRepository, Repository>();

builder.Services.AddHostedService<CommandWorker>();

var host = builder.Build();
await host.RunAsync();
