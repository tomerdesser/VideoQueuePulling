using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncodingModule
{
	public interface IVideoEncodingFlowTriggerer
	{
		void Trigger();
	}

	public class VideoEncodingFlowTriggerer : IVideoEncodingFlowTriggerer
	{
		private readonly IVideoIdToEncodeProvider _videoIdToEncodeProvider;
		private readonly IVideoEncodingFlow _videoEncodingFlow;

		public VideoEncodingFlowTriggerer(IVideoIdToEncodeProvider videoIdToEncodeProvider, IVideoEncodingFlow videoEncodingFlow)
		{
			_videoIdToEncodeProvider = videoIdToEncodeProvider;
			_videoEncodingFlow = videoEncodingFlow;
		}

		public void Trigger()
		{
			var videoId = _videoIdToEncodeProvider.Provide();
			_videoEncodingFlow.Run(videoId);
		}
	}
}
