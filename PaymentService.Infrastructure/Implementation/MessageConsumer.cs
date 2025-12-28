using PaymentService.Infrastructure.Configuration;
using PaymentService.SharedKernel.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Infrastructure.Implementation
{
	public class MessageConsumer : IMessageConsumer
	{
		private const string QueueName = "CaptainAmerica-CA.Payment.queue";
		public async Task<string> StartConsumingAsync()
		{
			using var connection = await RabbitMqConnection.CreateConnectionAsync();
			using var channel = await connection.CreateChannelAsync();
			var consumer = new AsyncEventingBasicConsumer(channel);

			string message = string.Empty;

			consumer.ReceivedAsync += async (sender, args) =>
			{
				var body = args.Body.ToArray();
				message = Encoding.UTF8.GetString(body);

				Console.WriteLine($"[x] Received: {message}");


				await Task.CompletedTask;
			};

			await channel.BasicConsumeAsync(
				queue: QueueName,
				autoAck: true,
				consumer: consumer);

			return message;
			Console.WriteLine("Consumer started. Press [Enter] to exit.");
			Console.ReadLine();
		}
	}
}
