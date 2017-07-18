namespace VideoEncodingModule.Domain.Contracts
{
	public interface IWebClient
	{
		void GetVideoFromUrl(Video video);
	}
}