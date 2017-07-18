using VideoEncodingModule.Domain.Contracts;

namespace VideoEncodingModule.Domain.VideoEncodingHandlers
{
	public class VideoDownloader : VideoEncodingHandlerBase
	{
		private readonly IWebClient _webClient;

		public VideoDownloader(IVideosRepository videosRepository, IWebClient webClient) : base(videosRepository)
		{
			_webClient = webClient;
		}

		public override VideoProcessStep VideoServiceProcessStep => VideoProcessStep.VideoDownload;

		protected override void HandleAfterReport(Video video)
		{
			_webClient.GetVideoFromUrl(video);
		}
	}
}