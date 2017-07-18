using System.Reflection;
using Autofac;
using VideoEncodingModule.DataAccess;
using VideoEncodingModule.DataAccess.VideosRepository;
using VideoEncodingModule.DataAccess.WcfRequestHandler;
using VideoEncodingModule.Domain;
using VideoEncodingModule.Domain.Contracts;
using VideoEncodingModule.Domain.VideoEncodingHandlers;

namespace ServiceRegistration
{
	public class AutofacRegistration
	{
		public static IContainer GenerateContainer()
		{
			var builder = new ContainerBuilder();

			// Register components.
			builder.RegisterAssemblyTypes(Assembly.Load("VideoEncodingModule.Domain")).InstancePerLifetimeScope().AsImplementedInterfaces();
			builder.RegisterAssemblyTypes(Assembly.Load("VideoEncodingModule.DataAccess")).InstancePerLifetimeScope().AsImplementedInterfaces();
			builder.RegisterType<VideosRepository>().As<IVideosRepository>();
			builder.RegisterType<IftpRequestHandler>().As<IFtpRequestHandler>();
			builder.RegisterType<VideoLocalsHandler>().As<IVideoLocalsHandler>();
			builder.RegisterType<WebClientImplementation>().As<IWebClient>();
			



			return builder.Build();
		}
	}
}
