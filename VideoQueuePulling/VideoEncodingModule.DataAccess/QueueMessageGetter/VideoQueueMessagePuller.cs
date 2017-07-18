using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using VideoEncodingModule.Domain;
using VideoEncodingModule.Domain.Contracts;

namespace VideoEncodingModule.DataAccess.QueueMessageGetter
{
	public class VideoQueueMessagePuller : IVideoQueueMessagePuller
	{
		private readonly IVideoEncodingFlow _videoEncodingFlow;

		public VideoQueueMessagePuller(IVideoEncodingFlow videoEncodingFlow)
		{
			_videoEncodingFlow = videoEncodingFlow;
		}

		public void StartPullingVideos()
		{
			var factory = new ConnectionFactory { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			{
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare(queue: "videos_queue1", durable: true, exclusive: false, autoDelete: false, arguments: null);
					var consumer = new EventingBasicConsumer(channel);
					consumer.Received += TriggerFlow;
					channel.BasicConsume(queue: "videos_queue1", noAck: false, consumer: consumer);
				}
			}
		}

		private void TriggerFlow(object model, BasicDeliverEventArgs ea)
		{
			var body = ea.Body;
			var message = Encoding.UTF8.GetString(body);
			long videoId;
			long.TryParse(message, out videoId);
			_videoEncodingFlow.Run(videoId);
		}
	}
}