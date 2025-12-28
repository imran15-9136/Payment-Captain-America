using PaymentService.SharedKernel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCommendWorkerHost.Implementation
{
	internal class CommandHandler(IMessageConsumer _messageConsumer) : ICommandHandler
	{
		public async Task HandleAsync(CancellationToken cancellationToken = default)
		{
			try
			{
				while (!cancellationToken.IsCancellationRequested)
				{
					var message = await _messageConsumer.StartConsumingAsync();
				}
			}
			catch (Exception ex)
			{
				await Task.Delay(5000, cancellationToken);
			}

			
		}
	}
}
