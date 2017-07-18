using System.Collections.Generic;

namespace VideoEncodingModule.Domain.Contracts
{
	public interface IVideoLocalsHandler
	{
		void CreateOutputDirectory(long videoId);
		void CreateRootDirectory(long videoId);
		void SaveFile(long videoId, string fileName, string format, string content);
		void DeleteVideoLocals(long videoId);
		IEnumerable<string> GetAllProcessedVideos(long videoId);
		byte[] ReadVideo(string filePath);
	}
}