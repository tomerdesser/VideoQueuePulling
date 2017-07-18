using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using VideoEncodingModule.DataAccess.VideosRepository;

namespace VideoEncodingModule.DataAccess
{
	public static class SessionOpener
	{
		private const string DbServer = "localhost";
		private const string DbUsername = "root";
		private const string DbName = "videos_db";
		private const string DbPassword = "MF12345";

		public static ISession OpenSession()
		{
			var sessionFactory = Fluently.Configure()
				.Database(MySQLConfiguration.Standard.ConnectionString(c => c.Server(DbServer).Database(DbName).Username(DbUsername).Password(DbPassword)))
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<VideoDto>())
				.BuildSessionFactory();

			return sessionFactory.OpenSession();
		}
	}
}