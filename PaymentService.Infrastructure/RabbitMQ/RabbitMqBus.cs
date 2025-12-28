using PaymentService.SharedKernel.Dto;
using PaymentService.SharedKernel.Interface;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaymentService.Infrastructure.Implementation
{
	public class RabbitMqBus : IServiceBus
	{
		private const string QueueName = "CaptainAmerica-CA.Payment.queue";
		public async Task PublishAsync(IPaymentRequestCommand messege)
		{
			using var connection = await RabbitMqConnection.CreateConnectionAsync();
			using var channel = await connection.CreateChannelAsync();

			await channel.QueueDeclareAsync(
				queue: QueueName,
				durable: true,
				exclusive: false,
				autoDelete: false,
				arguments: null);

			var json = JsonSerializer.Serialize(messege);
			var body = Encoding.UTF8.GetBytes(json);


			var properties = new BasicProperties
			{
				Persistent = true   // ensures message durability
			};

			await channel.ExchangeDeclareAsync(
					exchange: "payment.exchange",
					type: ExchangeType.Direct,
					durable: true,
					autoDelete: false);

			await channel.QueueBindAsync(
					queue: QueueName,
					exchange: "payment.exchange",
					routingKey: QueueName);


			await channel.BasicPublishAsync(
				exchange: "payment.exchange",
				routingKey: QueueName,
				mandatory: true,
				basicProperties: properties,
				body: body);
		}
	}
}
