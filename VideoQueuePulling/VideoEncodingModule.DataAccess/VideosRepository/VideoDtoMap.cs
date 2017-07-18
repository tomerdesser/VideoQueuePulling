using FluentNHibernate.Mapping;

namespace VideoEncodingModule.DataAccess.VideosRepository
{
	public class VideoDtoMap : ClassMap<VideoDto>
	{
		public VideoDtoMap()
		{
			Table("videos");

			Id(x => x.Id);
			Map(x => x.Url);
			Map(x => x.ProcessStep);
		}
	}
}