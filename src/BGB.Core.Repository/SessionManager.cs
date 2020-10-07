using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using System;
using System.IO;
using System.Reflection;

namespace BGB.Core.Repository
{
    public static class SessionManager
    {

        #region [ Privates ]
        private const string KeyDbConnection = "Data Source=BGB005SQL;Initial Catalog=DBInternetBanking;user=user.sys;pwd=ws3ed;";
        private const string CurrentSessionKey = "nhibernate.current_session";

        private static ISessionFactory _sessionFactory;

        private static string GetPathBinMap()
        {
            var uriBuilder = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
            var assemblyPath = Uri.UnescapeDataString(uriBuilder.Path);
            var pathBase = Path.GetDirectoryName(assemblyPath);
            var nameAssembly = "BGB.InternetBanking.Maps.dll";

            return Path.Combine(pathBase, nameAssembly);
        }


        #endregion [ Privates ]

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        static SessionManager()
        {
            _sessionFactory = CreateSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var sessionHibernate = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2012.ConnectionString(KeyDbConnection))
                 .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                 .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.LoadFile(GetPathBinMap())))
                 .CurrentSessionContext<WebSessionContext>()
                 .BuildSessionFactory();

            return sessionHibernate;
        }

    }
}