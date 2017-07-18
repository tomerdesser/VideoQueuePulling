using System.Linq;
using NHibernate.Linq;
using VideoEncodingModule.Domain;
using VideoEncodingModule.Domain.Contracts;

namespace VideoEncodingModule.DataAccess.VideosRepository
{
	public class VideosRepository : IVideosRepository
	{
		private readonly IVideoMapper _videoMapper;

		public VideosRepository(IVideoMapper videoMapper)
		{
			_videoMapper = videoMapper;
		}

		public Video Get(long videoId)
		{
			using (var session = SessionOpener.OpenSession())
			{
				var dto = session.Query<VideoDto>().FirstOrDefault(x => x.Id == videoId);
				return _videoMapper.Map(dto);
			}
		}

		public void Set(Video video)
		{
			var dto = _videoMapper.Map(video);
			using (var session = SessionOpener.OpenSession())
			{
				session.SaveOrUpdate(dto);
				session.Flush();
			}
		}
	}
}