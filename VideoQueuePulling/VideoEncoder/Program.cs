using System.Text;
using Autofac;
using RabbitMQ.Client;
using ServiceRegistration;
using VideoEncodingModule.Domain.Contracts;

namespace VideoEncoder
{
	class Program
	{
		static void Main(string[] args)
		{
			var container = AutofacRegistration.GenerateContainer();

			/*Run flow after queuing a message*/
			var videoQueueMessagePuller = container.Resolve<IVideoQueueMessagePuller>();
			videoQueueMessagePuller.StartPullingVideos();

			CreatMessage(123L);
		}

		private static void CreatMessage(long videoId)
		{
			var factory = new ConnectionFactory { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "videos_queue1", durable: true, exclusive: false, autoDelete: false, arguments: null);

				var message = videoId.ToString();
				var body = Encoding.UTF8.GetBytes(message);

				var properties = channel.CreateBasicProperties();
				properties.Persistent = true;

				channel.BasicPublish(exchange: "",
									 routingKey: "videos_queue1",
									 basicProperties: properties,
									 body: body);
			}
		}
	}
}
