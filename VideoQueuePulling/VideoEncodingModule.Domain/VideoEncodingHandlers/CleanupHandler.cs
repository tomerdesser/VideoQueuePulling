using VideoEncodingModule.Domain.Contracts;

namespace VideoEncodingModule.Domain.VideoEncodingHandlers
{
	public class CleanupHandler : VideoEncodingHandlerBase
	{
		private readonly IVideoLocalsHandler _videoLocalsHandler;

		public CleanupHandler(IVideosRepository videosRepository, IVideoLocalsHandler videoLocalsHandler) : base(videosRepository)
		{
			_videoLocalsHandler = videoLocalsHandler;
		}

		public override VideoProcessStep VideoServiceProcessStep => VideoProcessStep.CleanUp;

		protected override void HandleAfterReport(Video video)
		{
			_videoLocalsHandler.DeleteVideoLocals(video.Id);
		}
	}
}