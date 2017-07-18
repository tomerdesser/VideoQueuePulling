namespace VideoEncodingModule
{
	public interface IVideoIdToEncodeProvider
	{
		long? Provide();
	}
}