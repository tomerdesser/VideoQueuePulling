namespace VideoEncodingModule.Domain
{
	public class Video
	{
		public long Id { get; set; }
		public string Url { get; set; }
		public VideoProcessStep ProcessStep { get; set; }
	}

	public enum VideoProcessStep
	{
		WaitForProcessToBegin = 0,
		VideoDownload = 1,
		VideoConvert = 2,
		VideoUpload = 3,
		CleanUp = 4
	}
}