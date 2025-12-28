using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Infrastructure.Configuration
{
	internal class RabbitMqConnection
	{
		public static async Task<IConnection> CreateConnectionAsync()
		{
			var factory = new ConnectionFactory
			{
				HostName = "fuji.lmq.cloudamqp.com",
				UserName = "iqpehepr",
				Password = "dk0_-GdhN5eQA-R4w583zNmx5LtO-i_3",
				VirtualHost = "iqpehepr",
			};

			return await factory.CreateConnectionAsync();
		}
	}
}
