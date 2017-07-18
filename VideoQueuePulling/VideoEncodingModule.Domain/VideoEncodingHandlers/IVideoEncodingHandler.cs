namespace VideoEncodingModule.Domain.VideoEncodingHandlers
{
	public interface IVideoEncodingHandler
	{
		bool ShouldHandle(Video video);
		void Handle(Video video);
		VideoProcessStep VideoServiceProcessStep { get; }
	}
}