using System.Net;
using VideoEncodingModule.Domain.Contracts;

namespace VideoEncodingModule.DataAccess.WcfRequestHandler
{
	public class IftpRequestHandler : IFtpRequestHandler
	{
		private const string HostAddress = "ftp://localhost";
		private const string UserName = "green";
		private const string Password = "123";

		public void CreateDirectory(long videoId)
		{
			try
			{
				var request = CreateRequest($"{HostAddress}/{videoId}", WebRequestMethods.Ftp.MakeDirectory);
				var response = (FtpWebResponse) request.GetResponse();
				response.Close();
			}
			catch (WebException ex)
			{
				var response = (FtpWebResponse)ex.Response;
				if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
				{
					response.Close();
					return;
				}

				response.Close();
				throw;
			}
		}

		public void UploadFile(byte[] fileContent, long videoId, string fileName)
		{
			var request = CreateRequest($"{HostAddress}/{videoId}/{fileName}", WebRequestMethods.Ftp.UploadFile);
			request.ContentLength = fileContent.Length;

			var requestStream = request.GetRequestStream();
			requestStream.Write(fileContent, 0, fileContent.Length);
			requestStream.Close();

			var response = (FtpWebResponse)request.GetResponse();

			response.Close();
		}

		private static FtpWebRequest CreateRequest(string ftpPath, string requestMethod)
		{
			var request = (FtpWebRequest) WebRequest.Create(ftpPath);
			request.Method = requestMethod;
			request.Credentials = new NetworkCredential(UserName, Password);
			return request;
		}
	}
}