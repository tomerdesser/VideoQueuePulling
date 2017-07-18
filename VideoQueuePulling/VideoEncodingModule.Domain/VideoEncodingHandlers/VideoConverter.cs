using VideoEncodingModule.Domain.Contracts;

namespace VideoEncodingModule.Domain.VideoEncodingHandlers
{
	public class VideoConverter : VideoEncodingHandlerBase
	{
		private readonly IVideoLocalsHandler _videoLocalsHandler;
		private readonly string[] _formats = {"mp4", "wmv"};

		public VideoConverter(IVideosRepository videosRepository, IVideoLocalsHandler videoLocalsHandler) : base(videosRepository)
		{
			_videoLocalsHandler = videoLocalsHandler;
		}

		public override VideoProcessStep VideoServiceProcessStep => VideoProcessStep.VideoConvert;

		protected override void HandleAfterReport(Video video)
		{
			_videoLocalsHandler.CreateOutputDirectory(video.Id);
			foreach (var format in _formats)
			{
				var content = string.Empty;
				const string fileName = "output";
				_videoLocalsHandler.SaveFile(video.Id, fileName, format, content);
			}
		}
	}
}