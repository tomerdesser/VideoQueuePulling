using VideoEncodingModule.Domain.Contracts;

namespace VideoEncodingModule.Domain.VideoEncodingHandlers
{
	public abstract class VideoEncodingHandlerBase : IVideoEncodingHandler
	{
		private readonly IVideosRepository _videosRepository;
		public abstract VideoProcessStep VideoServiceProcessStep { get; }

		protected VideoEncodingHandlerBase(IVideosRepository videosRepository)
		{
			_videosRepository = videosRepository;
		}

		public bool ShouldHandle(Video video)
		{
			return video.ProcessStep <= VideoServiceProcessStep;
		}

		public void Handle(Video video)
		{
			video.ProcessStep = VideoServiceProcessStep;
			_videosRepository.Set(video);

			HandleAfterReport(video);
		}

		protected abstract void HandleAfterReport(Video video);
	}
}