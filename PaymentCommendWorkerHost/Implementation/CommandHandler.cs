using PaymentService.SharedKernel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCommendWorkerHost.Implementation
{
	internal class CommandHandler(IMessageConsumer message) : ICommandHandler
	{
		public async Task HandleAsync()
		{
			await message.StartConsumeAsync();
		}
	}
}
