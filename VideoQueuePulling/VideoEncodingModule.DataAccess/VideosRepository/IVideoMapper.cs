using System;
using VideoEncodingModule.Domain;

namespace VideoEncodingModule.DataAccess.VideosRepository
{
	public interface IVideoMapper
	{
		Video Map(VideoDto dto);
		VideoDto Map(Video video);
	}

	public class VideoMapper : IVideoMapper
	{
		public Video Map(VideoDto dto)
		{
			if (dto == null)
				return null;
			VideoProcessStep videoProcessStep;
			Enum.TryParse(dto.ProcessStep, true, out videoProcessStep);

			return new Video
			{
				Id = dto.Id,
				Url = dto.Url,
				ProcessStep = videoProcessStep
				
			};
		}

		public VideoDto Map(Video video)
		{
			if (video == null)
				return null;

			return new VideoDto
			{
				Id = video.Id,
				Url = video.Url,
				ProcessStep = video.ProcessStep.ToString()
			};
		}
	}
}