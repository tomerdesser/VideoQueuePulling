namespace VideoEncodingModule.DataAccess.VideosRepository
{
	public class VideoDto
	{
		public virtual long Id { get; set; }
		public virtual string Url { get; set; }
		public virtual string ProcessStep { get; set; }
	}
}