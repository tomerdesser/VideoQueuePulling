using System.Linq;
using VideoEncodingModule.Domain.Contracts;
using VideoEncodingModule.Domain.VideoEncodingHandlers;

namespace VideoEncodingModule.Domain
{
	public interface IVideoEncodingFlow
	{
		void Run(long videoId);
	}

	public class VideoEncodingFlow : IVideoEncodingFlow
	{
		private const long DefaultVideoId = 0L;
		private readonly IVideosRepository _videosRepository;
		private readonly IVideoEncodingHandler[] _videoEncodingHandlers;

		public VideoEncodingFlow(IVideosRepository videosRepository, IVideoEncodingHandler[] videoEncodingHandlers)
		{
			_videosRepository = videosRepository;
			_videoEncodingHandlers = videoEncodingHandlers;
		}

		public void Run(long videoId)
		{
			if (videoId == DefaultVideoId)
				return;

			var videoToEncode = _videosRepository.Get(videoId);
			if (videoToEncode == null)
				return;

			var handlers = _videoEncodingHandlers.Where(x => x.ShouldHandle(videoToEncode)).OrderBy(y => y.VideoServiceProcessStep).ToArray();

			foreach (var videoEncodingHandler in handlers)
			{
				videoEncodingHandler.Handle(videoToEncode);
			}
		}
	}
}