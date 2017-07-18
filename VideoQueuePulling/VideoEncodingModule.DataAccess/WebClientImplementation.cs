using System.Net;
using VideoEncodingModule.Domain;
using VideoEncodingModule.Domain.Contracts;

namespace VideoEncodingModule.DataAccess
{
	public class WebClientImplementation : IWebClient
	{
		private readonly IVideoLocalsHandler _videoLocalsHandler;

		public WebClientImplementation(IVideoLocalsHandler videoLocalsHandler)
		{
			_videoLocalsHandler = videoLocalsHandler;
		}

		public void GetVideoFromUrl(Video video)
		{
			_videoLocalsHandler.CreateRootDirectory(video.Id);
			using (var myWebClient = new WebClient())
			{
				myWebClient.DownloadFile(video.Url, $"TempVideoForlder/{video.Id}/VideoDownloadTest");
			}
		}
	}
}