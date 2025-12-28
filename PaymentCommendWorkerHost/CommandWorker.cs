using Microsoft.Extensions.Hosting;
using PaymentService.SharedKernel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCommendWorkerHost
{
	internal class CommandWorker(ICommandHandler commandHandler) : BackgroundService
	{
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			try
			{
				await commandHandler.HandleAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in CommandWorker: {ex.Message}");
			}

		}
	}
}
