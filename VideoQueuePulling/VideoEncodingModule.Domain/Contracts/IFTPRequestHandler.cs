namespace VideoEncodingModule.Domain.Contracts
{
	public interface IFtpRequestHandler
	{
		void CreateDirectory(long videoId);
		void UploadFile(byte[] fileContent, long videoId, string fileName);
	}
}