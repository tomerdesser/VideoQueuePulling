namespace VideoEncodingModule.Domain.Contracts
{
	public interface IVideoQueueMessagePuller
	{
		void StartPullingVideos();
	}
}