// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaymentCommendWorkerHost;
using PaymentCommendWorkerHost.Implementation;
using PaymentService.Infrastructure.Implementation;
using PaymentService.SharedKernel.Interface;

Console.WriteLine("Hello, World!");

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IMessageConsumer, MessageConsumer>();
builder.Services.AddTransient<ICommandHandler, CommandHandler>();
builder.Services.AddTransient<IRepository, Repository>();

builder.Services.AddHostedService<CommandWorker>();

var host = builder.Build();
await host.RunAsync();
