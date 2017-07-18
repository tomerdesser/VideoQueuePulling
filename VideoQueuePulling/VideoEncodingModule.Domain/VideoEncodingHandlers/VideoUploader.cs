using System.Linq;
using VideoEncodingModule.Domain.Contracts;

namespace VideoEncodingModule.Domain.VideoEncodingHandlers
{
	public class VideoUploader : VideoEncodingHandlerBase
	{
		private readonly IFtpRequestHandler _iftpRequestHandler;
		private readonly IVideoLocalsHandler _videoLocalsHandler;

		public VideoUploader(IVideosRepository videosRepository, IFtpRequestHandler iftpRequestHandler, IVideoLocalsHandler videoLocalsHandler) : base(videosRepository)
		{
			_iftpRequestHandler = iftpRequestHandler;
			_videoLocalsHandler = videoLocalsHandler;
		}

		public override VideoProcessStep VideoServiceProcessStep => VideoProcessStep.VideoUpload;

		protected override void HandleAfterReport(Video video)
		{
			_iftpRequestHandler.CreateDirectory(video.Id);
			var filesPath = _videoLocalsHandler.GetAllProcessedVideos(video.Id);

			foreach (var filePath in filesPath)
			{
				var fileContent = _videoLocalsHandler.ReadVideo(filePath);
				var fileName = filePath.Split('/').Last();
				_iftpRequestHandler.UploadFile(fileContent, video.Id, fileName);
			}
		}
	}
}