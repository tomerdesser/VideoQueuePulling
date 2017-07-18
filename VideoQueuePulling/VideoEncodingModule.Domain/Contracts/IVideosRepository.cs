namespace VideoEncodingModule.Domain.Contracts
{
	public interface IVideosRepository
	{
		Video Get(long videoId);
		void Set(Video video);
	}
}