using System.Collections.Generic;
using System.IO;
using VideoEncodingModule.Domain.Contracts;

namespace VideoEncodingModule.DataAccess
{
	public class VideoLocalsHandler : IVideoLocalsHandler
	{
		public void DeleteVideoLocals(long videoId)
		{
			Directory.Delete(GetVideoRootPath(videoId), true);
		}

		public IEnumerable<string> GetAllProcessedVideos(long videoId)
		{
			var filesPath = Directory.GetFiles(GetVideoOutputPath(videoId), "*.*");
			return filesPath;
		}

		public byte[] ReadVideo(string filePath)
		{
			var fileContent = File.ReadAllBytes(filePath);
			return fileContent;
		}

		public void CreateOutputDirectory(long videoId)
		{
			Directory.CreateDirectory(GetVideoOutputPath(videoId));
		}

		public void CreateRootDirectory(long videoId)
		{
			Directory.CreateDirectory($"{GetVideoRootPath(videoId)}");
		}

		public void SaveFile(long videoId, string fileName, string format, string content)
		{
			File.WriteAllText($"{GetVideoOutputPath(videoId)}{fileName}.{format}", content);
		}

		private static string GetVideoOutputPath(long videoId)
		{
			return $"{GetVideoRootPath(videoId)}Output/";
		}

		private static string GetVideoRootPath(long videoId)
		{
			return $"TempVideoForlder/{videoId}/";
		}
	}
}